// File: IHikAGVService
// Author: linxmouse@gmail.com
// Creation: 2022/6/16 21:20:03
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HikRCS.AspNetCore.Models;

namespace HikRCS.AspNetCore.Services
{
    /// <summary>
    /// 任务管理
    /// 释放AGV
    /// 获取任务状态
    /// 创建、继续、取消任务
    /// </summary>
    public interface IHikRobotService
    {
        /// <summary>
        /// 创建任务
        /// reqCode: 请求编号，每个请求都要一个唯一编号， 同一个请求重复提交， 使用同一编号
        /// reqTime: 请求时间截 格式: “yyyy-MM-dd HH:mm:ss”
        /// taskTyp: 任务类型
        /// priority: 优先级，从（1~5）级，最大优先级最高
        /// taskCode: 任务单号,选填, 不填系统自动生成，必须为 32 位 UUID
        /// agvCode: AGV 编号，填写表示指定某一编号的 AGV 执行该任务
        /// </summary>
        Task<(bool success, string message)> CreateTask(HikNewTaskModel genTaskModel);
        /// <summary>
        /// 继续任务
        /// </summary>
        Task<(bool success, string message)> ContinueTask(HikContinueTaskModel continueTaskModel);
        /// <summary>
        /// 取消任务
        /// </summary>
        Task<(bool success, string message)> CancelTask(HikCancelTaskModel cancelTaskModel);
        /// <summary>
        /// 释放AGV
        /// </summary>
        Task<(bool success, string message)> FreeRobot(HikFreeRobotModel freeRobotModel);
        /// <summary>
        /// 获取任务状态
        /// </summary>
        Task<HikTaskStatusOutModel> GetTaskStatus(HikTaskStatusInModel taskStatusInModel);
        /// <summary>
        /// 查询AGV状态信息、电池电量
        /// 调用频次:
        /// 100车以下5秒 
        /// 100-200车10秒 
        /// 200-300车15秒
        /// </summary>
        Task<HikRobotStatusOutModel> GetRobotStatus(HikRobotStatusInModel robotStatusInModel);
        /// <summary>
        /// 停止指定或全部AGV
        /// </summary>
        Task<(bool success, string message)> StopRobot(HikStopAndResumeRobotInModel robotInModel);
        /// <summary>
        /// 恢复AGV,恢复后继续执行未完成的任务
        /// </summary>
        Task<(bool success, string message)> ResumeRobot(HikStopAndResumeRobotInModel robotInModel);
    }
}
