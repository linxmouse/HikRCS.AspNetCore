// File: HikResult
// Author: linxmouse@gmail.com
// Creation: 2022/6/22 10:21:39
using System;
using System.Collections.Generic;
using System.Text;

namespace HikRCS.AspNetCore.Services
{
    public class HikResult<TResult>
        where TResult : class, new()
    {
        public bool success { get; set; }
        public string message { get; set; }
        public TResult data { get; set; } = default(TResult)!;
    }
}
