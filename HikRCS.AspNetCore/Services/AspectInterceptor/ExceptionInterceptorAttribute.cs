// File: ExceptionInterceptorAttribute
// Author: linxmouse@gmail.com
// Creation: 2022/6/22 22:27:43
using AspectCore.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HikRCS.AspNetCore.Services.AspectInterceptor
{
    public class ExceptionInterceptorAttribute : AbstractInterceptorAttribute
    {
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var logger = context.ServiceProvider.GetRequiredService<ILogger<ExceptionInterceptorAttribute>>();
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex.Message);
                throw;
            }
        }
    }
}
