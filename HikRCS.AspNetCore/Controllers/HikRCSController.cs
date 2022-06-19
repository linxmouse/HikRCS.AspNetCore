// File: NotifyController
// Author: linxmouse@gmail.com
// Creation: 2022/6/16 12:45:17
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HikRCS.AspNetCore.Models;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace HikRCS.AspNetCore.Controllers
{
    [EnableCors("HikRCSAny")]
    [Route("restapi/HikIntegration/[action]")]
    [ApiController]
    public class HikRCSController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HikRCSController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 模板任务状态回调
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Status(HikNotifyModel notifyModel)
        {
            await _mediator.Publish(new HikRCSCallEvent { EventType = EventType.Status, Method = notifyModel.method });

            return Ok(new MyReplyModel());
        }

        /// <summary>
        /// 告警推送回调的方法
        /// 调度系统将导致 AGV 停止运行的严重告警推送给上层系统
        /// 推送频率10秒一次
        /// 该接口路径必须为： http://IP:PORT/service/rest/agvCallbackService/warnCallback
        /// </summary>
        [HttpPost("/service/rest/agvCallbackService/warnCallback")]
        //[Route("/service/rest/agvCallbackService/warnCallback")]
        public async Task<IActionResult> Warn(HikWarnModel warnModel)
        {
            if (warnModel.warnInfos.Any())
            {
                await _mediator.Publish(new HikRCSCallEvent { EventType = EventType.Warn, WarnDescs = warnModel.warnInfos });
            }

            return Ok(new MyReplyModel());
        }

        /// <summary>
        /// 可在执行绑定货架与储位,绑定货架与物料,绑定仓位与容器后通知上层
        /// 该接口路径必须为： http://IP:PORT/service/rest/bindNotify
        /// </summary>
        [HttpPost("/service/rest/bindNotify")]
        public async Task<IActionResult> Bind(object param)
        {
            return Ok(new MyReplyModel());
        }
    }
}
