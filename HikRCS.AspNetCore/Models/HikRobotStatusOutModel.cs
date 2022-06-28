// File: HikRobotStatusOutModel
// Author: linxmouse@gmail.com
// Creation: 2022/6/19 13:08:06
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HikRCS.AspNetCore.Models
{
    public class HikRobotStatusDesc
    {
        /// <summary>
        /// 机器人编号
        /// </summary>
        public string robotCode { get; set; }
        /// <summary>
        /// 机器人方向(范围-180-360°)
        /// </summary>
        public string robotDir { get; set; }
        /// <summary>
        /// 机器人IP
        /// </summary>
        public string robotIp { get; set; }
        /// <summary>
        /// 机器人电量(范围0-100)
        /// </summary>
        public string battery { get; set; }
        /// <summary>
        /// 机器人x坐标(单位:毫米)
        /// </summary>
        public string posX { get; set; }
        /// <summary>
        /// 机器人y坐标(单位:毫米)
        /// </summary>
        public string posY { get; set; }
        /// <summary>
        /// 机器人所在地图
        /// </summary>
        public string mapCode { get; set; }
        /// <summary>
        /// 机器人当前速度(单位:mm/s)
        /// </summary>
        public string speed { get; set; }
        /// <summary>
        /// 机器人状态
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 是否已被排除，被排除后不接受新任务(1-排除,0-正常)
        /// </summary>
        public string exclType { get; set; }
        /// <summary>
        /// 是否暂停(0-否,1-是)
        /// </summary>
        public string stop { get; set; }
        /// <summary>
        /// 背货架的编号
        /// </summary>
        public string podCode { get; set; }
        /// <summary>
        /// 背货架的方向
        /// </summary>
        public string podDir { get; set; }
        /// <summary>
        /// 执行路径,单位是毫米
        /// 示例:["[x,y,dir]","[x,y,dir]"]
        /// </summary>
        public string[] path { get; set; }
    }

    public class HikRobotStatusOutModel
    {
        /// <summary>
        /// 返回码
        /// 0-成功
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 请求编号
        /// </summary>
        public string reqCode { get; set; }
        /// <summary>
        /// AGV状态列表
        /// </summary>
        public List<HikRobotStatusDesc> data { get; set; }
    }
}
