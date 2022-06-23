// File: HikNotifyModel
// Author: linxmouse@gmail.com
// Creation: 2022/6/16 22:34:38
using System;
using System.Collections.Generic;
using System.Text;

namespace HikRCS.Client.Models
{
    public class HikNotifyModel
    {
        /// <summary>
        /// 请求编号
        /// </summary>
        public string reqCode { get; set; }
        /// <summary>
        /// 请求时间戳，格式: “yyyy-MM-dd  HH:mm:ss
        /// </summary>
        public string reqTime { get; set; }
        /// <summary>
        /// 地码 X 坐标(mm)：任务完成时有值
        /// </summary>
        public string cooX { get; set; }
        /// <summary>
        /// 地码 Y 坐标(mm)：任务完成时有值
        /// </summary>
        public string cooY { get; set; }
        /// <summary>
        /// 当前位置编号
        ///任务开始：该位置为任务起点
        ///走出储位：该位置为任务起点
        ///任务单取消：该位置为工作位编号
        /// 任务结束：该位置为任务终点
        /// </summary>
        public string currentPositionCode { get; set; }
        /// <summary>
        /// 自定义字段，不超过 2000 个字符
        /// </summary>
        public string data { get; set; }
        /// <summary>
        /// 地图编号
        /// </summary>
        public string mapCode { get; set; }
        /// <summary>
        /// 地码编号：任务完成时有值
        /// </summary>
        public string mapDataCode { get; set; }
        /// <summary>
        /// 方法名, 可使用任务类型做为方法 名
        /// 由 RCS-2000 任务模板配置后并告 知上层系统
        ///默认使用方式:
        ///start : 任务开始
        ///outbin : 走出储位
        ///end : 任务结束
        ///cancel : 任务单取消
        /// </summary>
        public string method { get; set; }
        /// <summary>
        /// 货架编号：背货架时有值
        /// </summary>
        public string podCode { get; set; }
        /// <summary>
        /// 180”,”0”,”90”,”-90” 分
        ///别 对应地图的 ” 左 ”,” 右 ”,”
        ///上”,”下”：任务完成时有值
        /// </summary>
        public string podDir { get; set; }
        /// <summary>
        /// AGV 编号（同 agvCode ）
        /// </summary>
        public string robotCode { get; set; }
        /// <summary>
        /// 当前任务单号
        /// </summary>
        public string taskCode { get; set; }
        /// <summary>
        /// 工作位，与 RCS-2000 端配置的位
        /// 置名称一致。任务完成时有值，与
        /// 生成任务单接口中的 wbCode 一致。
        /// </summary>
        public string wbCode { get; set; }
    }
}
