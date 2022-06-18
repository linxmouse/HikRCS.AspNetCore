// File: HikResponseModel
// Author: linxmouse@gmail.com
// Creation: 2022/6/16 23:09:42
using System;
using System.Collections.Generic;
using System.Text;

namespace HikRCS.AspNetCore.Models
{
    public class HikResponseModel
    {
        /// <summary>
        /// 返回码
        /// 0-成功
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 自定义返回
        /// </summary>
        public string data { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 请求编号
        /// </summary>
        public string reqCode { get; set; }
    }
}
