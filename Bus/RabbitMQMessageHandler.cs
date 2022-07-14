using Bus.ConfigurationModel;
using Domain.Events;
using Domain.Events.NotificationEvents;
using Domain.Interfaces;
using MassTransit;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Bus
{
    public class RabbitMQMessageHandler : IMessageBus
    {
        private readonly IBus _bus;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly RabbitMQModel _rabbitmqdata;
        public RabbitMQMessageHandler(IBus bus, IPublishEndpoint publishEndpoint, IOptionsMonitor<RabbitMQModel> optionsMonitor)
        {
            _bus = bus;
            _publishEndpoint = publishEndpoint;
            _rabbitmqdata = optionsMonitor.CurrentValue;
        }
        public async Task SendPushRequestedEvent(PushRequestedEvent _smsrequestedevent)
        {
            Uri uri = new Uri(_rabbitmqdata.Address + "/PushRequestedEvent");
            var endpoint = await _bus.GetSendEndpoint(uri);
            await endpoint.Send<PushRequestedEvent>(_smsrequestedevent);
        }

        public async Task SendSMSRequestedEvent(SMSRequestedEvent _smsrequestedevent)
        {
            Uri uri = new Uri(_rabbitmqdata.Address + "/SMSRequestedEvent");
            var endpoint = await _bus.GetSendEndpoint(uri);
            await endpoint.Send<SMSRequestedEvent>(_smsrequestedevent);
        }
    }
}
