using HikRCS.AspNetCore.Models;
using MediatR;

namespace HikRCSIntegration.Test.MediatorCommand
{
    public class HikRCSWarnCommand : INotificationHandler<HikWarnEvent>
    {
        private readonly ILogger<HikRCSCallCommand> _logger;

        public HikRCSWarnCommand(ILogger<HikRCSCallCommand> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 告警回调逻辑
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task Handle(HikWarnEvent notification, CancellationToken cancellationToken)
        {
            if (notification.WarnDescs.Any())
            {
                foreach (var item in notification.WarnDescs)
                {
                    _logger.LogInformation($"Begin Date: {item.beginDate}, Task code: {item.taskCode}, Warn content: {item.warnContent}");
                }
            }

            return Task.CompletedTask;
        }
    }
}
