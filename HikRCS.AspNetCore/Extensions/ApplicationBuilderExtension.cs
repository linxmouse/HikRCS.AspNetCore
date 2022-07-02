// File: ApplicationBuilderExtension
// Author: linxmouse@gmail.com
// Creation: 2022/6/19 15:40:52
using System;
using System.Text.RegularExpressions;
using Flurl.Http;
using HikRCS.Client.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HikRCS.AspNetCore.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder ApplyHikRCSIntegration(this IApplicationBuilder app)
        {
            var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("HikRCSIntegration");
            FlurlHttp.Configure(settings =>
            {
                var options = app.ApplicationServices.GetRequiredService<IOptions<HikRCSOptions>>().Value;
                if (options.LogFlurlRequest)
                {
                    settings.BeforeCall += call =>
                    {
                        var msg = call.HttpRequestMessage.ToString();
                        logger?.LogInformation(Regex.Replace(msg, "[\r\n]", ""));
                    };
                }
                settings.Timeout = TimeSpan.FromSeconds(3);
            });
            app.UseCors("HikRCSAny");

            return app;
        }
    }
}
