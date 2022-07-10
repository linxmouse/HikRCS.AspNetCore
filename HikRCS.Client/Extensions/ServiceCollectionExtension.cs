// File: ServiceCollectionExtension
// Author: linxmouse@gmail.com
// Creation: 2022/6/16 12:48:25
using System;
using System.Text.RegularExpressions;
using Flurl.Http;
using HikRCS.Client.Configuration;
using HikRCS.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HikRCS.Client.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddHikRCSClient(this IServiceCollection services, Action<HikOptions> options)
        {
            services.AddOptions();
            services.Configure<HikOptions>(options);

            services.AddTransient<IHikRobotService, HikRobotService>(provider =>
            {
                var op = provider.GetRequiredService<IOptions<HikOptions>>();
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
                });

                return ActivatorUtilities.GetServiceOrCreateInstance<HikRobotService>(provider);
            });

            return services;
        }

        public static IServiceCollection AddHikRCSClient(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection("HikRCS").Get<HikOptions>();
            services.AddOptions();
            services.Configure<HikOptions>(x =>
            {
                x.RCSUrl = options.RCSUrl;
                x.LogFlurlRequest = options.LogFlurlRequest;

                x.CreateTaskRouter = options.CreateTaskRouter;
                x.StopRobotRouter = options.StopRobotRouter;
                x.ResumeRobotRouter = options.ResumeRobotRouter;
                x.FreeRobotRouter = options.FreeRobotRouter;
                x.GetRobotStatusRouter = options.GetRobotStatusRouter;
                x.GetAgvStatusRouter = options.GetAgvStatusRouter;
                x.GetTaskStatusRouter = options.GetTaskStatusRouter;
                x.CancelTaskRouter = options.CancelTaskRouter;
                x.ContinueTaskRouter = options.ContinueTaskRouter;
                x.LoginRouter = options.LoginRouter;
                x.ChargeRouter = options.ChargeRouter;
            });

            services.AddTransient<IHikRobotService, HikRobotService>(provider =>
            {
                var op = provider.GetRequiredService<IOptions<HikOptions>>();
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
                });

                return ActivatorUtilities.GetServiceOrCreateInstance<HikRobotService>(provider);
            });

            return services;
        }

        public static IServiceCollection AddHikRCSClient<T>(this IServiceCollection services, Action<HikOptions> options)
            where T : class, IHikRobotService
        {
            services.AddOptions();
            services.Configure<HikOptions>(options);

            services.AddTransient<IHikRobotService, T>(provider =>
            {
                var op = provider.GetRequiredService<IOptions<HikOptions>>();
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
                });

                return ActivatorUtilities.GetServiceOrCreateInstance<T>(provider);
            });

            return services;
        }

        public static IServiceCollection AddHikRCSClient<T>(this IServiceCollection services, IConfiguration configuration)
            where T : class, IHikRobotService
        {
            var options = configuration.GetSection("HikRCS").Get<HikOptions>();
            services.AddOptions();
            services.Configure<HikOptions>(x =>
            {
                x.RCSUrl = options.RCSUrl;
                x.LogFlurlRequest = options.LogFlurlRequest;

                x.CreateTaskRouter = options.CreateTaskRouter;
                x.StopRobotRouter = options.StopRobotRouter;
                x.ResumeRobotRouter = options.ResumeRobotRouter;
                x.FreeRobotRouter = options.FreeRobotRouter;
                x.GetRobotStatusRouter = options.GetRobotStatusRouter;
                x.GetAgvStatusRouter = options.GetAgvStatusRouter;
                x.GetTaskStatusRouter = options.GetTaskStatusRouter;
                x.CancelTaskRouter = options.CancelTaskRouter;
                x.ContinueTaskRouter = options.ContinueTaskRouter;
                x.LoginRouter = options.LoginRouter;
                x.ChargeRouter = options.ChargeRouter;
            });

            services.AddTransient<IHikRobotService, T>(provider =>
            {
                var op = provider.GetRequiredService<IOptions<HikOptions>>();
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
                });

                return ActivatorUtilities.GetServiceOrCreateInstance<T>(provider);
            });

            return services;
        }
    }
}
