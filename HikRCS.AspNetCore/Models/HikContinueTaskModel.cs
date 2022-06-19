// File: HikContinueTaskModel
// Author: linxmouse@gmail.com
// Creation: 2022/6/17 10:52:54
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HikRCS.AspNetCore.Models
{
    /// <summary>
    /// wbCode、agvCode、taskCode 和 podCode 四个必须填一个，
    /// 优先级从高到低依次为：wbCode、taskCode、agvCode、podCode，
    /// 都传了优先使用 wbCode，以确定任务单编号。待
    /// 现场地图部署、配置完成后可获取
    /// </summary>
    public class HikContinueTaskModel
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
        /// 工作位，与 RCS-2000 端配置的位置名称一致
        /// </summary>
        public string wbCode { get; set; }
        /// <summary>
        /// 任务单号,选填, 不填系统自动生成，必须为 32 位 UUID
        /// </summary>
        public string taskCode { get; set; }
        /// <summary>
        /// AGV 编号，填写表示指定某一编号的 AGV 执行该任务
        /// </summary>
        public string agvCode { get; set; }
        /// <summary>
        /// 货架号，采用货架号触发的方式
        /// </summary>
        public string podCode { get; set; }
    }
}
