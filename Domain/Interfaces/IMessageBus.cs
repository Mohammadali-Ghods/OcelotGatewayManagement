using Domain.Events;
using Domain.Events.NotificationEvents;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMessageBus
    {
        Task SendPushRequestedEvent(PushRequestedEvent _smsrequestedevent);
        Task SendSMSRequestedEvent(SMSRequestedEvent _smsrequestedevent);
    }
}
