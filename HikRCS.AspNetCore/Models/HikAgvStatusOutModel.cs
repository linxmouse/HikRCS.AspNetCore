// File: HikAgvStatusOutModel
// Author: linxmouse@gmail.com
// Creation: 2022/6/28 11:17:34
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HikRCS.AspNetCore.Models
{
    public class HikAgvStatusDesc
    {
        /// <summary>
        /// 电量
        /// </summary>
        public string battery { get; set; }
        public string direction { get; set; }
        /// <summary>
        /// 是否排除状态
        /// 0-未排除
        /// 1-排除
        /// </summary>
        public string exclude { get; set; }
        /// <summary>
        /// 是否排除文本描述
        /// </summary>
        public string excludeStr { get; set; }
        public string podCode { get; set; }
        public string podDir { get; set; }
        public string posX { get; set; }
        public string posY { get; set; }
        public string robotCode { get; set; }
        public string robotIp { get; set; }
        /// <summary>
        /// 状态编号
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 状态描述文本
        /// </summary>
        public string statusStr { get; set; }
        /// <summary>
        /// 是否暂停状态
        /// 0-未暂停
        /// 1-已暂停
        /// </summary>
        public string stop { get; set; }
        /// <summary>
        /// 是否暂停文本描述
        /// </summary>
        public string stopStr { get; set; }
    }

    public class HikAgvStatusOutModel
    {
        /// <summary>
        /// 返回码
        /// 0-成功
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// Robot状态列表
        /// </summary>
        public List<HikAgvStatusDesc> data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string interrupt { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 请求编号
        /// </summary>
        public string reqCode { get; set; }
    }
}
