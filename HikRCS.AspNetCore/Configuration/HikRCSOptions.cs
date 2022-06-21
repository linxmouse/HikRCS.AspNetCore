// File: HikRCSOptions
// Author: linxmouse@gmail.com
// Creation: 2022/6/16 12:50:43
using System;
using System.Collections.Generic;
using System.Text;

namespace HikRCS.AspNetCore.Configuration
{
    public class HikRCSOptions
    {
        /// <summary>
        /// HikRCS的API基地址
        /// </summary>
        public string RCSUrl { get; set; }
        /// <summary>
        /// 是否打印Flurl的请求日志
        /// </summary>
        public bool LogFlurlRequest { get; set; } = true;

        public string CreateTaskRouter { get; set; } = ":8182/rcms/services/rest/hikRpcService/genAgvSchedulingTask";
        public string ContinueTaskRouter { get; set; } = ":8182/rcms/services/rest/hikRpcService/continueTask";
        public string CancelTaskRouter { get; set; } = ":8182/rcms/services/rest/hikRpcService/cancelTask";
        public string GetTaskStatusRouter { get; set; } = ":8182/rcms/services/rest/hikRpcService/queryTaskStatus";
        public string GetRobotStatusRouter { get; set; } = ":8083/rcms-dps/rest/queryAgvStatus";
        public string FreeRobotRouter { get; set; } = ":8182/rcms/services/rest/hikRpcService/freeRobot";
        public string StopRobotRouter { get; set; } = ":8182/rcms/services/rest/hikRpcService/stopRobot";
        public string ResumeRobotRouter { get; set; } = ":8182/rcms/services/rest/hikRpcService/resumeRobot";
    }
}
