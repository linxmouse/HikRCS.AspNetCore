using HikRCS.AspNetCore.Models;
using MediatR;

namespace HikRCSIntegration.Test.MediatorCommand
{
    public class HikRCSCallCommand : INotificationHandler<HikTaskNotifyEvent>
    {
        private readonly ILogger<HikRCSCallCommand> _logger;

        public HikRCSCallCommand(ILogger<HikRCSCallCommand> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 处理状态回调逻辑
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task Handle(HikTaskNotifyEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Method: {notification.TaskNotify.method}");

            return Task.CompletedTask;
        }
    }
}
