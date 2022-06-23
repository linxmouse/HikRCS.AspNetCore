// File: PositionCodePath
// Author: linxmouse@gmail.com
// Creation: 2022/6/17 10:19:16
using System;
using System.Collections.Generic;
using System.Text;

namespace HikRCS.Client.Models
{
    /// <summary>
    ///位置路径：
    ///     AGV 关键路径位置集合，
    ///     与任务类型中模板配置的位置路径
    ///     一一对应。待现场地图部署、配置
    ///     完成后可获取
    ///
    /// positionCode:位置编号
    ///     位置类型说明:
    ///     00 表示：位置编号
    ///     01 表示：物料批次号
    ///     02 表示：策略编号（含多个区域）
    ///     如：第一个区域放不下, 可以放第二
    ///     个区域
    ///     03 表示：货架编号，通过货架编号
    ///     找到货架所在位置
    ///     04 表示：区域编号，在区域中查找
    ///     可用位置
    /// </summary>
    public class MapPositionCodePath
    {
        public string positionCode { get; set; }
        public string type { get; set; } = "00";
    }
}
