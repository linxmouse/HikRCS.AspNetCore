// File: AGVStatusModel
// Author: linxmouse@gmail.com
// Creation: 2022/6/17 10:33:01
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace HikRCS.Client.Models
{
    public class HikTaskStatusDesc
    {
        /// <summary>
        /// 任务编号
        /// </summary>
        public string taskCode { get; set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        public string taskTyp { get; set; }
        /// <summary>
        /// 任务状态：
        /// 0-发送异常
        /// 1-已创建
        /// 2-正在执行
        /// 3-正在发送
        /// 4-正在取消
        /// 5-取消完成
        /// 6-正在重发
        /// 9-已结束
        /// 10-被打断
        /// 0、1、2、5、9常用
        /// </summary>
        public string taskStatus { get; set; }
    }

    public class HikTaskStatusOutModel
    {
        /// <summary>
        /// 返回编号，0：成功 1~N ：失败
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 返回的数据结构
        /// </summary>
        public List<HikTaskStatusDesc> data { get; set; }

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
