// File: HikChargeModel
// Author: linxmouse@gmail.com
// Creation: 2022/7/8 18:46:22
using System;
using System.Collections.Generic;
using System.Text;

namespace HikRCS.Client.Models
{
    public class HikRobotChargeModel
    {
        /// <summary>
        /// ECS用户名
        /// </summary>
        public string ecsUserName { get; set; } = "admin";
        /// <summary>
        /// ECS密码
        /// MD5 Lower case
        /// </summary>
        public string lowerMd5Password { get; set; }
        /// <summary>
        /// 管理员编码
        /// </summary>
        public int pwdSafeLevelLogin { get; set; } = 3;
        /// <summary>
        /// AGV编号
        /// </summary>
        public string agvCode { get; set; }
        /// <summary>
        /// 充电编码
        /// 1-充电
        /// 0-取消充电
        /// </summary>
        public int chargeCode { get; set; }
    }
}
