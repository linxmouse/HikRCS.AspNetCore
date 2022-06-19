// File: HikFreeAGVModel
// Author: linxmouse@gmail.com
// Creation: 2022/6/17 11:49:41
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HikRCS.AspNetCore.Models
{
    public class HikFreeRobotModel
    {
        /// <summary>
        /// 请求编号
        /// 每个请求都要一个唯一编号
        /// 同一个请求重复提交使用同一编号
        /// </summary>
        [Required]
        public string reqCode { get; set; }
        /// <summary>
        /// AGV编号
        /// </summary>
        public string robotCode { get; set; }
    }
}
