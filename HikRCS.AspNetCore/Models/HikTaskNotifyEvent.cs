// File: HikRCSEvent
// Author: linxmouse@gmail.com
// Creation: 2022/6/16 22:02:07
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace HikRCS.AspNetCore.Models
{
    /// <summary>
    /// 发布RCS回调数据到业务层
    /// </summary>
    public class HikTaskNotifyEvent: INotification
    {
        /// <summary>
        /// 通知的Method的名称
        /// </summary>
        public HikTaskNotifyModel TaskNotify { get; set; }
    }
}
