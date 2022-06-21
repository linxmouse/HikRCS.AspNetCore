## 说明

独立出与海康RCS通信交互部分，可以有更多的精力关注业务层，更好的代码复用节约开发时间

1. 包括RCS的消息推送：状态、告警、Sync等的处理﻿
2. 提供对RCS API接口的调用：创建、继续、取消任务，释放AGV等

完全插件式使用

- [x] 使用默认的HikAGVService

```c#
public static IMvcBuilder AddHikRCSIntegration(this IMvcBuilder builder, Action<HikRCSOptions> options)
{
    builder.Services.AddOptions();
    builder.Services.Configure<HikRCSOptions>(options);

    builder.Services.AddTransient<IHikAGVService, HikAGVService>();
    builder.AddApplicationPart(typeof(HikRCSController).Assembly);

    return builder;
}
```

- [x] 使用自定义实现的IHikAGVService

```c#
public static IMvcBuilder AddHikRCSIntegration<T>(this IMvcBuilder builder, Action<HikRCSOptions> options)
    where T : class, IHikAGVService
{
    builder.Services.AddOptions();
    builder.Services.Configure<HikRCSOptions>(options);

    builder.Services.AddTransient<IHikAGVService, T>();
    builder.AddApplicationPart(typeof(HikRCSController).Assembly);

    return builder;
}
```

## GettingStarted（食用方法）

1. 创建一个测试使用的WebAPI项目，如下

   ```c#
   using HikRCS.AspNetCore.Extensions;
   using MediatR;
   
   var builder = WebApplication.CreateBuilder(args);
   
   // Add services to the container.
   
   builder.Services.AddMediatR(typeof(Program).Assembly);
   builder.Services.AddControllers();
   // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
   builder.Services.AddEndpointsApiExplorer();
   builder.Services.AddSwaggerGen();
   
   var app = builder.Build();
   
   // Configure the HTTP request pipeline.
   if (app.Environment.IsDevelopment())
   {
       app.UseSwagger();
       app.UseSwaggerUI();
   }
   
   // 添加回调控制器的跨域支持
   // 调用必须放在UseRouting之后,但在UseAuthorization之前,参考https://docs.microsoft.com/zh-cn/aspnet/core/fundamentals/middleware/?view=aspnetcore-6.0#middleware-order
   app.ApplyHikRCSIntegration();
   app.UseAuthorization();
   
   app.MapControllers();
   
   app.Run();
   ```

2. 在AddControllers()后面也就是本HikRCSIntegration中实现的IMvcBuilder的扩展方法，如下

   ```c#
   builder.Services
       .AddControllers()
       .AddHikRCSIntegration(options =>
       {
           options.RCSUrl = "http://192.168.2.3";

            //// default configuration
            //options.CreateTaskRouter = ":8182/rcms/services/rest/hikRpcService/genAgvSchedulingTask";
            //options.ContinueTaskRouter = ":8182/rcms/services/rest/hikRpcService/continueTask";
            //options.CancelTaskRouter = ":8182/rcms/services/rest/hikRpcService/cancelTask";
            //options.GetTaskStatusRouter = ":8182/rcms/services/rest/hikRpcService/queryTaskStatus";
            //options.GetRobotStatusRouter = ":8083/rcms-dps/rest/queryAgvStatus";
            //options.FreeRobotRouter = ":8182/rcms/services/rest/hikRpcService/freeRobot";
            //options.StopRobotRouter = ":8182/rcms/services/rest/hikRpcService/stopRobot";
            //options.ResumeRobotRouter = ":8182/rcms/services/rest/hikRpcService/resumeRobot";
       });
   ```

3. 现实MediatR的`INotificationHandler<HikRCSCallEvent>`，如下

   ```c#
   using HikRCS.AspNetCore.Models;
   using MediatR;
   
   namespace HikRCSIntegration.Test.MediatorCommand
   {
       public class HikRCSCallCommand : INotificationHandler<HikRCSCallEvent>
       {
           private readonly ILogger<HikRCSCallCommand> _logger;
   
           public HikRCSCallCommand(ILogger<HikRCSCallCommand> logger)
           {
               _logger = logger;
           }
   
           /// <summary>
           /// 这里专注处理业务代码
           /// </summary>
           public Task Handle(HikRCSCallEvent notification, CancellationToken cancellationToken)
           {
               if (notification.EventType == EventType.Notify)
                   _logger.LogInformation($"Event type: {notification.EventType}, Method: {notification.Method}");
               else if (notification.EventType == EventType.Warn)
               {
                   foreach (var item in notification.WarnDescs)
                   {
                       _logger.LogInformation($"Event type: {notification.EventType}, Begin Date: {item.beginDate}, Task code: {item.taskCode}, Warn content: {item.warnContent}");
                   }
               }
                   
               return Task.CompletedTask;
           }
       }
   }
   ```

4. ***欧克，下面来验证一下结果***

   分别使用**丝袜哥**调用两个提供给HikRCS的两个接口

   ```bash
   curl -X 'POST' \
     'http://localhost:5244/restapi/HikIntegration/Status' \
     -H 'accept: */*' \
     -H 'Content-Type: application/json' \
     -d '{
     "reqCode": "string",
     "reqTime": "string",
     "cooX": "string",
     "cooY": "string",
     "currentPositionCode": "string",
     "data": "string",
     "mapCode": "string",
     "mapDataCode": "string",
     "method": "RCS回调.method=测试",
     "podCode": "string",
     "podDir": "string",
     "robotCode": "string",
     "taskCode": "string",
     "wbCode": "string"
   }'
   ```

   ```bash
   curl -X 'POST' \
     'http://localhost:5244/restapi/HikIntegration/Warn' \
     -H 'accept: */*' \
     -H 'Content-Type: application/json' \
     -d '{
     "reqCode": "string",
     "reqTime": "string",
     "clientCode": "string",
     "tokenCode": "string",
     "warnInfos": [
       {
         "robotCode": "034",
         "beginDate": "2022-06-18T13:56:30.521Z",
         "warnContent": "爆炸告警测试",
         "taskCode": "001122334455"
       }
     ]
   }'
   ```

   **查看结果**

   ```bash
   info: HikRCSIntegration.Test.MediatorCommand.HikRCSCallCommand[0]
         Event type: Notify, Method: RCS回调.method=测试
   info: HikRCSIntegration.Test.MediatorCommand.HikRCSCallCommand[0]
         Event type: Warn, Begin Date: 2022/6/18 13:56:30, Task code: 001122334455, Warn content: 爆炸告警测试
   ```

   

   

   