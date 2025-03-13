using MasstransitRabbitMQ.Consumer.API.Abstractions.Messages;
using MasstransitRabbitMQ.Contract.IntegrationEvents;
using MediatR;

namespace MasstransitRabbitMQ.Consumer.API.MessageBus.Consumers.Events;

public class SendSmsWhenReceivedEventConsumer : Consumer<DomainEvent.SmsNotificationEvent>
{
    public SendSmsWhenReceivedEventConsumer(ISender sender) : base(sender)
    {
    }
}
