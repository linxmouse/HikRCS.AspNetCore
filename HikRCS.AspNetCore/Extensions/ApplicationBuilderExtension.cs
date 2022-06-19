// File: ApplicationBuilderExtension
// Author: linxmouse@gmail.com
// Creation: 2022/6/19 15:40:52
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace HikRCS.AspNetCore.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder ApplyHikRCSIntegration(this IApplicationBuilder app)
        {
            app.UseCors("HikRCSAny");

            return app;
        }
    }
}
