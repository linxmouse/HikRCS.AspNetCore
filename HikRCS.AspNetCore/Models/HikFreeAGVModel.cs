// File: HikFreeAGVModel
// Author: linxmouse@gmail.com
// Creation: 2022/6/17 11:49:41
using System;
using System.Collections.Generic;
using System.Text;

namespace HikRCS.AspNetCore.Models
{
    public class HikFreeAGVModel
    {
        /// <summary>
        /// 请求编号
        /// </summary>
        public string reqCode { get; set; }
        /// <summary>
        /// AGV编号
        /// </summary>
        public string robotCode { get; set; }
    }
}
