// File: HikRobotStatusOutModel
// Author: linxmouse@gmail.com
// Creation: 2022/6/19 13:08:06
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HikRCS.Client.Models
{
    public enum HikRobotStatus
    {
        [Description("Task completed")]
        任务完成 = 1,
        [Description("Executing task")]
        任务执行中 = 2,
        [Description("Abnornal task")]
        任务异常 = 3,
        [Description("Idle task")]
        任务空闲 = 4,
        [Description("Robot stopped")]
        机器人暂停 = 5,
        [Description("Lifting shelf status")]
        举升货架状态 = 6,
        [Description("Charging status")]
        充电状态 = 7,
        [Description("Battery arcing in progress")]
        弧线行走中 = 8,
        [Description("Fully charged, entering maintenance mode")]
        充满维护 = 9,
        [Description("Carried item not recognized")]
        背货未识别 = 11,
        [Description("Excessive shelf angle divergence")]
        货架偏角过大 = 12,
        [Description("Motion library exception")]
        运动库异常 = 13,
        [Description("Unable to recognise product code")]
        货码无法识别 = 14,
        [Description("Product code mismatch")]
        货码不匹配 = 15,
        [Description("Lift abnormal")]
        举升异常 = 16,
        [Description("Charging post abnormal")]
        充电桩异常 = 17,
        [Description("No increase in current")]
        电量无增加 = 18,
        [Description("Angle error in charging directive")]
        充电指令角度错误 =20,
        [Description("Platform decentralisation directive error")]
        平台下发指令错误 = 21,
        [Description("External force, unloading")]
        外力下放 = 23,
        [Description("Misaligned shelf")]
        货架位置偏移 = 24,
        [Description("Trolley not in designated zone")]
        小车不在锁定区 = 25,
        [Description("Decentralisation failed")]
        下放重试失败 = 26,
        [Description("Uneven shelf")]
        货架摆歪 = 27,
        [Description("Lift battery current too low")]
        举升电池电量太低 = 28,
        [Description("Wide reversing angle")]
        后退角度偏大 = 29,
        [Description("No shelf detected")]
        未背货架举升 = 30,
        [Description("Failed to lock zone")]
        区域锁定失败 = 31,
        [Description("Rotation request temporarily failed")]
        旋转申请暂时失败 = 33,
        [Description("Unable to recognise coordinates to switch maps")]
        地图切换点地码未识别 = 34
    }

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
