// File: HikRobotStatus
// Author: linxmouse@gmail.com
// Creation: 2022/6/28 11:40:42
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        地图切换点地码未识别 = 34,
        [Description("Deviation Exception")]
        异常偏航 = 35,

        [Description("Obstacles Ahead")]
        前方遇障 = 81,
        [Description("Obstacles Behind")]
        后方遇障 = 82,
        [Description("Obstacles on the left")]
        左侧遇障 = 83,
        [Description("No moving path")]
        右侧遇障 = 84,               

        [Description("Standby Mode")]
        待机模式中 = 246,
        [Description("Low Power Mode")]
        低功耗模式中 = 247,
        [Description("Sleep Mode")]
        休眠模式中 = 248,
        [Description("Sleep Abnormal")]
        异常休眠模式 = 249,
        [Description("The battery is too low")]
        电量过低预警 = 250,
        [Description("Wake up failed")]
        机器人唤醒失败 = 253
    }
}
