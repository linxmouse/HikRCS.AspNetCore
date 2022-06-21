// File: HikStopRobotInModel
// Author: linxmouse@gmail.com
// Creation: 2022/6/19 13:10:02
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HikRCS.AspNetCore.Models
{
    public class HikStopAndResumeRobotInModel
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
        /// 客户端编号，如PDA,HCWMS等
        /// </summary>
        public string clientCode { get; set; }
        /// <summary>
        /// 令牌号，由调度系统颁发
        /// </summary>
        public string tokenCode { get; set; }
        /// <summary>
        /// 停止/恢复的机器人数(-1表示所有机器人)
        /// </summary>
        public string robotCount { get; set; }
        /// <summary>
        /// 地图简称(robotCount为-1时此项必填)
        /// </summary>
        public string mapShortName { get; set; }
        /// <summary>
        /// 具体机器人编号列表
        /// </summary>
        public List<string> robots { get; set; }
    }
}
