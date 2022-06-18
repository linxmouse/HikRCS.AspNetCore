// File: NotifyController
// Author: linxmouse@gmail.com
// Creation: 2022/6/16 12:45:17
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HikRCS.AspNetCore.Models;
using System.Linq;

namespace HikRCS.AspNetCore.Controllers
{
    [Route("restapi/HikIntegration/[action]")]
    [ApiController]
    public class HikRCSController: ControllerBase
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
            await _mediator.Publish(new HikRCSCallEvent { EventType = EventType.Notify, Method = notifyModel.method });

            return Ok(new MyReplyModel());
        }

        /// <summary>
        /// 告警通知 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Warn(HikWarnModel warnModel)
        {
            if (warnModel.warnInfos.Any())
            {
                await _mediator.Publish(new HikRCSCallEvent { EventType = EventType.Warn, WarnDescs = warnModel.warnInfos});
            }

            return Ok(new MyReplyModel());
        }
    }
}
