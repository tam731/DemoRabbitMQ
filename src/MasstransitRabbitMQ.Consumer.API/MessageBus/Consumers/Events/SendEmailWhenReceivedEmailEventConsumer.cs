using MasstransitRabbitMQ.Consumer.API.Abstractions.Messages;
using MasstransitRabbitMQ.Contract.IntegrationEvents;
using MediatR;

namespace MasstransitRabbitMQ.Consumer.API.MessageBus.Consumers.Events
{
    public class SendEmailWhenReceivedEmailEventConsumer : Consumer<DomainEvent.EmailNotificationEvent>
    {
        public SendEmailWhenReceivedEmailEventConsumer(ISender sender) : base(sender)
        {
        }
    }
}
