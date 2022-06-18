// File: HikRCSEvent
// Author: linxmouse@gmail.com
// Creation: 2022/6/16 22:02:07
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace HikRCS.AspNetCore.Models
{
    public enum EventType
    {
        /// <summary>
        /// 通知
        /// </summary>
        Notify,
        /// <summary>
        /// 告警
        /// </summary>
        Warn
    }

    /// <summary>
    /// 发布RCS回调数据到业务层
    /// </summary>
    public class HikRCSCallEvent: INotification
    {
        public EventType EventType { get; set; } = EventType.Notify;
        /// <summary>
        /// 通知的Method的名称
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// 告警的内容
        /// </summary>
        public List<HikAGVWarnDesc> WarnDescs { get; set; }
    }
}
