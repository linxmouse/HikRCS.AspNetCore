// File: HikAgvStatusInModel
// Author: linxmouse@gmail.com
// Creation: 2022/6/28 11:17:14
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HikRCS.Client.Models
{
    public class HikAgvStatusInModel
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
        /// AGV编号列表
        /// </summary>
        public string[] robots { get; set; }
    }
}
