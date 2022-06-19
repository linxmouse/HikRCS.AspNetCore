using HikRCS.AspNetCore.Models;
using MediatR;

namespace HikRCSIntegration.Test.MediatorCommand
{
    public class HikRCSCallCommand : INotificationHandler<HikRCSCallEvent>
    {
        private readonly ILogger<HikRCSCallCommand> _logger;

        public HikRCSCallCommand(ILogger<HikRCSCallCommand> logger)
        {
            _logger = logger;
        }

        public Task Handle(HikRCSCallEvent notification, CancellationToken cancellationToken)
        {
            if (notification.EventType == EventType.Status)
                _logger.LogInformation($"Event type: {notification.EventType}, Method: {notification.Method}");
            else if (notification.EventType == EventType.Warn)
            {
                foreach (var item in notification.WarnDescs)
                {
                    _logger.LogInformation($"Event type: {notification.EventType}, Begin Date: {item.beginDate}, Task code: {item.taskCode}, Warn content: {item.warnContent}");
                }
            }
                
            return Task.CompletedTask;
        }
    }
}
