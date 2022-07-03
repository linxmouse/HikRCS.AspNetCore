// File: HikRCSWarnEvent
// Author: linxmouse@gmail.com
// Creation: 2022/6/21 20:27:31
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace HikRCS.AspNetCore.Models
{
    public class HikWarnEvent: INotification
    {
        /// <summary>
        /// 告警的内容
        /// </summary>
        public List<HikRobotWarnDesc> WarnDescs { get; set; }
    }
}
