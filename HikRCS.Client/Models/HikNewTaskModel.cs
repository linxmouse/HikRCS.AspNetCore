// File: AGVTaskModel
// Author: linxmouse@gmail.com
// Creation: 2022/6/17 10:32:44
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HikRCS.Client.Models
{
    public class HikNewTaskModel
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
        /// 任务类型
        /// </summary>
        public string taskTyp { get; set; }
        public List<MapPositionCodePath> positionCodePath { get; set; }
        /// <summary>
        /// 优先级，从（1~5）级，最大优先级最高
        /// </summary>
        public string priority { get; set; }
        /// <summary>
        /// 任务单号,选填, 不填系统自动生成，必须为 32 位 UUID
        /// </summary>
        public string taskCode { get; set; }
        /// <summary>
        /// AGV 编号，填写表示指定某一编号的 AGV 执行该任务
        /// </summary>
        public string agvCode { get; set; }
    }
}
