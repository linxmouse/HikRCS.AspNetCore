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
    [Route("/service/rest/[action]")]
    [ApiController]
    public class HikController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HikController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 模板任务状态回调
        /// </summary>
        [HttpPost("/service/rest/taskNotify")]
        public async Task<IActionResult> TaskNotify(HikTaskNotifyModel notifyModel)
        {
            await _mediator.Publish(new HikTaskNotifyEvent { TaskNotify = notifyModel });

            return Ok(new
            {
                code = "0",
                reqCode = notifyModel.reqCode,
                message = "成功"
            });
        }

        /// <summary>
        /// 告警推送回调的方法
        /// 调度系统将导致AGV停止运行的严重告警推送给上层系统
        /// 推送频率10秒一次
        /// 该接口路径必须为:http://IP:PORT/service/rest/agvCallbackService/warnCallback
        /// </summary>
        [HttpPost("/service/rest/agvCallbackService/warnCallback")]
        public async Task<IActionResult> Warn(HikWarnModel warnModel)
        {
            if (warnModel.warnInfos.Any())
            {
                await _mediator.Publish(new HikWarnEvent { WarnDescs = warnModel.warnInfos });
            }

            return Ok(new
            {
                code = "0",
                reqCode = warnModel.reqCode,
                message = "成功"
            });
        }
    }
}
