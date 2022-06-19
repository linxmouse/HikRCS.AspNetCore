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

        public string CreateTaskRouter { get; set; } = "/genAgvSchedulingTask";
        public string ContinueTaskRouter { get; set; } = "/continueTask";
        public string CancelTaskRouter { get; set; } = "/cancelTask";
        public string GetTaskStatusRouter { get; set; } = "/queryTaskStatus";
        public string GetRobotStatusRouter { get; set; } = "/queryAgvStatus";
        public string FreeRobotRouter { get; set; } = "/freeRobot";
        public string StopRobotRouter { get; set; } = "/stopRobot";
        public string ResumeRobotRouter { get; set; } = "resumeRobot";
    }
}
