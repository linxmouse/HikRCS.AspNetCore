﻿// File: ServiceCollectionExtension
// Author: linxmouse@gmail.com
// Creation: 2022/6/16 12:48:25
using System;
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
            builder.Services.AddOptions();
            builder.Services.Configure<HikRCSOptions>(options);

            builder.Services.AddTransient<IHikAGVService, HikAGVService>();
            builder.AddApplicationPart(typeof(HikRCSController).Assembly);

            return builder;
        }

        public static IMvcBuilder AddHikRCSIntegration<T>(this IMvcBuilder builder, Action<HikRCSOptions> options)
            where T : class, IHikAGVService
        {
            builder.Services.AddOptions();
            builder.Services.Configure<HikRCSOptions>(options);

            builder.Services.AddTransient<IHikAGVService, T>();
            builder.AddApplicationPart(typeof(HikRCSController).Assembly);

            return builder;
        }
    }
}