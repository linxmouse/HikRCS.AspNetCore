// File: HikAGVWarnModel
// Author: linxmouse@gmail.com
// Creation: 2022/6/16 22:09:42
using System;
using System.Collections.Generic;
using System.Text;

namespace HikRCS.AspNetCore.Models
{
    public class HikAGVWarnDesc
    {
        /// <summary>
        /// 车号
        /// </summary>
        public string robotCode { get; set; }
        /// <summary>
        /// 告警开始时间
        /// </summary>
        public DateTime beginDate { get; set; }
        /// <summary>
        /// 告警内容
        /// </summary>
        public string warnContent { get; set; }
        /// <summary>
        /// 任务号
        /// </summary>
        public string taskCode { get; set; }
    }

    public class HikWarnModel
    {
        /// <summary>
        /// 请求编号
        /// </summary>
        public string reqCode { get; set; }
        /// <summary>
        /// 请求时间戳
        /// </summary>
        public string reqTime { get; set; }
        /// <summary>
        /// 客户端编号
        /// </summary>
        public string clientCode { get; set; }
        /// <summary>
        /// HikRCS颁发的令牌号
        /// </summary>
        public string tokenCode { get; set; }
        /// <summary>
        /// 告警信息
        /// </summary>
        public List<HikAGVWarnDesc> warnInfos { get; set; }
    }
}
