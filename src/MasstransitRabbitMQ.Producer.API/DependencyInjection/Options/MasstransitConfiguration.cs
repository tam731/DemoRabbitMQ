namespace MasstransitRabbitMQ.Producer.API.DependencyInjection.Options
{
    public class MasstransitConfiguration
    {
        public string Host { get; set; } = default!;
        public string VHost { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ExchangeName { get; set; } = default!;
        public string ExchangeType { get; set; } = default!;
        public string SmsQueueName { get; set; } = default!;
        public string EmailQueueName { get; set; } = default!;
    }
}
