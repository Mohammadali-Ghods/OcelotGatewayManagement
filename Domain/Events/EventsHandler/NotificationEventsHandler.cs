using Domain.Events.NotificationEvents;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Events.EventsHandler
{
    public class NotificationEventsHandler:
        INotificationHandler<SMSRequestedEvent>,
        INotificationHandler<PushRequestedEvent>
    {
        IMessageBus _messagebus;
        public NotificationEventsHandler(IMessageBus messagebus)
        {
            _messagebus = messagebus;
        }
        public Task Handle(SMSRequestedEvent notification, CancellationToken cancellationToken)
        {
            _messagebus.SendSMSRequestedEvent(notification);
            return Task.CompletedTask;
        }

        public Task Handle(PushRequestedEvent notification, CancellationToken cancellationToken)
        {
            _messagebus.SendPushRequestedEvent(notification);
            return Task.CompletedTask;
        }
    }
}
