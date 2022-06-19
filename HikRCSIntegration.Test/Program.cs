using HikRCS.AspNetCore.Extensions;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services
    .AddControllers()
    .AddHikRCSIntegration(options =>
    {
        options.RCSUrl = "http://127.0.0.1:8182";
    });
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
