// File: HikGetTaskStatusModel
// Author: linxmouse@gmail.com
// Creation: 2022/6/17 11:17:16
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HikRCS.AspNetCore.Models
{
    /// <summary>
    /// 任务编号数组与 AGV 编号至少传其中之一
    /// </summary>
    public class HikTaskStatusInModel
    {
        /// <summary>
        /// 请求编号
        /// 每个请求都要一个唯一编号
        /// 同一个请求重复提交使用同一编号
        /// </summary>
        [Required]
        public string reqCode { get; set; }
        /// <summary>
        /// 请求时间截 格式: “yyyy-MM-dd HH:mm:ss”
        /// </summary>
        public string reqTime { get; set; }
        /// <summary>
        /// 任务编号数组
        /// </summary>
        public List<string> taskCodes { get; set; }
        /// <summary>
        /// AGV 编号
        /// </summary>
        public string agvCode { get; set; }
    }
}
