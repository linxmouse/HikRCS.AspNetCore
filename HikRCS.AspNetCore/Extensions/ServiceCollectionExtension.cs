// File: ServiceCollectionExtension
// Author: linxmouse@gmail.com
// Creation: 2022/6/16 12:48:25
using System;
using AspectCore.Extensions.DependencyInjection;
using HikRCS.AspNetCore.Configuration;
using HikRCS.AspNetCore.Controllers;
using HikRCS.AspNetCore.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HikRCS.AspNetCore.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IMvcBuilder AddHikRCSIntegration(this IMvcBuilder builder, Action<HikRCSOptions> options)
        {
            builder.Services.ConfigureDynamicProxy();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("HikRCSAny", pb => pb.AllowAnyOrigin());
            });

            builder.Services.AddOptions();
            builder.Services.Configure<HikRCSOptions>(options);

            builder.Services.AddTransient<IHikRobotService, HikRobotService>();
            builder.AddApplicationPart(typeof(HikRCSController).Assembly);

            return builder;
        }

        public static IMvcBuilder AddHikRCSIntegration<T>(this IMvcBuilder builder, Action<HikRCSOptions> options)
            where T : class, IHikRobotService
        {
            builder.Services.ConfigureDynamicProxy();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("HikRCSAny", pb => pb.AllowAnyOrigin());
            });

            builder.Services.AddOptions();
            builder.Services.Configure<HikRCSOptions>(options);

            builder.Services.AddTransient<IHikRobotService, T>();
            builder.AddApplicationPart(typeof(HikRCSController).Assembly);

            return builder;
        }
    }
}
