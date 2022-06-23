// File: HikCancelTaskModel
// Author: linxmouse@gmail.com
// Creation: 2022/6/17 11:05:46
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HikRCS.Client.Models
{
    /// <summary>
    /// taskCode 和 agvCode 选一项填写
    /// 优先级从高到低依次为：agvCode、taskCode
    /// 都传了优先使用 agvCode，以确定需要取消哪个任务单
    /// 取消任务单后可释放对应的 AGV
    /// </summary>
    public class HikCancelTaskModel
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
        /// AGV 编号，填写表示指定某一编号的 AGV 执行该任务
        /// </summary>
        public string agvCode { get; set; }
        /// <summary>
        /// 任务单号,选填, 不填系统自动生成，必须为 32 位 UUID
        /// </summary>
        public string taskCode { get; set; }
        
    }
}
