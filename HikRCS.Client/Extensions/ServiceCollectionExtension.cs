// File: ServiceCollectionExtension
// Author: linxmouse@gmail.com
// Creation: 2022/6/16 12:48:25
using System;
using System.Text.RegularExpressions;
using Flurl.Http;
using HikRCS.Client.Configuration;
using HikRCS.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HikRCS.Client.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddHikRCSClient(this IServiceCollection services, Action<HikRCSOptions> options)
        {
            services.AddOptions();
            services.Configure<HikRCSOptions>(options);

            services.AddTransient<IHikRobotService, HikRobotService>(provider =>
            {
                var op = provider.GetRequiredService<IOptions<HikRCSOptions>>();
                var logger = provider.GetRequiredService<ILoggerFactory>().CreateLogger("HikRCSIntegration");
                FlurlHttp.Configure(settings =>
                {
                    var config = op.Value;
                    if (config.LogFlurlRequest)
                    {
                        settings.BeforeCall += call =>
                        {
                            var msg = call.HttpRequestMessage.ToString();
                            logger?.LogInformation(Regex.Replace(msg, "[\r\n]", ""));
                        };
                    }
                    settings.Timeout = TimeSpan.FromSeconds(3);
                });

                return ActivatorUtilities.GetServiceOrCreateInstance<HikRobotService>(provider);
            });

            return services;
        }

        public static IServiceCollection AddHikRCSClient<T>(this IServiceCollection services, Action<HikRCSOptions> options)
            where T : class, IHikRobotService
        {
            services.AddOptions();
            services.Configure<HikRCSOptions>(options);

            services.AddTransient<IHikRobotService, T>(provider =>
            {
                var op = provider.GetRequiredService<IOptions<HikRCSOptions>>();
                var logger = provider.GetRequiredService<ILoggerFactory>().CreateLogger("HikRCSIntegration");
                FlurlHttp.Configure(settings =>
                {
                    var config = op.Value;
                    if (config.LogFlurlRequest)
                    {
                        settings.BeforeCall += call =>
                        {
                            var msg = call.HttpRequestMessage.ToString();
                            logger?.LogInformation(Regex.Replace(msg, "[\r\n]", ""));
                        };
                    }
                    settings.Timeout = TimeSpan.FromSeconds(3);
                });

                return ActivatorUtilities.GetServiceOrCreateInstance<T>(provider);
            });

            return services;
        }
    }
}
