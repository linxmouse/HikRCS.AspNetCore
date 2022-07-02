// File: ServiceCollectionExtension
// Author: linxmouse@gmail.com
// Creation: 2022/6/16 12:48:25
using System;
using HikRCS.AspNetCore.Controllers;
using HikRCS.Client.Configuration;
using HikRCS.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HikRCS.AspNetCore.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IMvcBuilder AddHikRCSIntegration(this IMvcBuilder builder, Action<HikRCSOptions> options)
        {
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

        public static IMvcBuilder AddHikRCSIntegration(this IMvcBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("HikRCSAny", pb => pb.AllowAnyOrigin());
            });

            var options = configuration.GetSection("HikRCS").Get<HikRCSOptions>();
            builder.Services.AddOptions();
            builder.Services.Configure<HikRCSOptions>(x =>
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
            });

            builder.Services.AddTransient<IHikRobotService, HikRobotService>();
            builder.AddApplicationPart(typeof(HikRCSController).Assembly);

            return builder;
        }

        public static IMvcBuilder AddHikRCSIntegration<T>(this IMvcBuilder builder, IConfiguration configuration)
            where T : class, IHikRobotService
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("HikRCSAny", pb => pb.AllowAnyOrigin());
            });

            var options = configuration.GetSection("HikRCS").Get<HikRCSOptions>();
            builder.Services.AddOptions();
            builder.Services.Configure<HikRCSOptions>(x =>
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
            });

            builder.Services.AddTransient<IHikRobotService, T>();
            builder.AddApplicationPart(typeof(HikRCSController).Assembly);

            return builder;
        }
    }
}
