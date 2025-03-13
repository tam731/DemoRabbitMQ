using MassTransit;
using MasstransitRabbitMQ.Consumer.API.DependencyInjection.Options;
using MasstransitRabbitMQ.Consumer.API.MessageBus.Consumers.Events;
using System.Reflection;

namespace MasstransitRabbitMQ.Consumer.API.DependencyInjection.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMediatR(this IServiceCollection services)
        => services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

    public static IServiceCollection AddConfigureMasstransitRabbitMQ(this IServiceCollection services, IConfiguration configuration)
    {
        var masstransitConfiguration = new MasstransitConfiguration();
        configuration.GetSection(nameof(MasstransitConfiguration)).Bind(masstransitConfiguration);


        services.AddMassTransit(mt =>
        {
            //mt.AddConsumer<SendSmsWhenReceivedEventConsumer>();
            mt.AddConsumers(Assembly.GetExecutingAssembly()); //Add consumer
            mt.UsingRabbitMq((context, bus) =>
            {
                bus.Host(masstransitConfiguration.Host, h =>
                {
                    h.Username(masstransitConfiguration.UserName);
                    h.Password(masstransitConfiguration.Password);
                });

                bus.ConfigureEndpoints(context);
            });
        });
        return services;
    }
}
