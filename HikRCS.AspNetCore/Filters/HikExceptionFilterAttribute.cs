// File: HikExceptionFilterAttribute
// Author: linxmouse@gmail.com
// Creation: 2022/7/3 17:15:21
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HikRCS.AspNetCore.Filters
{
    public class HikExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<HikExceptionFilterAttribute> _logger;

        public HikExceptionFilterAttribute(ILogger<HikExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                _logger.LogWarning(context.HttpContext.Request.Path, context.Exception);

                context.Result = new ContentResult
                {
                    StatusCode = StatusCodes.Status200OK,
                    ContentType = "application/json;charset=utf-8",
                    Content = JsonConvert.SerializeObject(new
                    {
                        code = "0",
                        message = "成功"
                    })
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
