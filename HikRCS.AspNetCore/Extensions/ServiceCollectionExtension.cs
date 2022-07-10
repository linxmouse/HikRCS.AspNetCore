// File: ServiceCollectionExtension
// Author: linxmouse@gmail.com
// Creation: 2022/6/16 12:48:25
using System;
using HikRCS.AspNetCore.Controllers;
using HikRCS.Client.Configuration;
using HikRCS.Client.Extensions;
using HikRCS.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HikRCS.AspNetCore.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IMvcBuilder AddHikRCSIntegration(this IMvcBuilder builder, Action<HikOptions> options)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("HikAny", pb => pb.AllowAnyOrigin());
            });

            builder.Services.AddHikRCSClient(options);
            builder.AddApplicationPart(typeof(HikController).Assembly);

            return builder;
        }

        public static IMvcBuilder AddHikRCSIntegration<T>(this IMvcBuilder builder, Action<HikOptions> options)
            where T : class, IHikRobotService
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("HikAny", pb => pb.AllowAnyOrigin());
            });

            builder.Services.AddHikRCSClient<T>(options);
            builder.AddApplicationPart(typeof(HikController).Assembly);

            return builder;
        }

        public static IMvcBuilder AddHikRCSIntegration(this IMvcBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("HikAny", pb => pb.AllowAnyOrigin());
            });

            builder.Services.AddHikRCSClient(configuration);
            builder.AddApplicationPart(typeof(HikController).Assembly);

            return builder;
        }

        public static IMvcBuilder AddHikRCSIntegration<T>(this IMvcBuilder builder, IConfiguration configuration)
            where T : class, IHikRobotService
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("HikAny", pb => pb.AllowAnyOrigin());
            });

            builder.Services.AddHikRCSClient<T>(configuration);
            builder.AddApplicationPart(typeof(HikController).Assembly);

            return builder;
        }
    }
}
