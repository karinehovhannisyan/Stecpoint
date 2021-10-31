using MassTransit;
using MassTransit.Messages;
using MassTransit.RabbitMqTransport;

namespace Stecpoint_Receiving_Service.StartupExtensions
{
    public static class MassTransitStartupExtension
    {
        public static void AddMassTransitConsumers(this IRabbitMqBusFactoryConfigurator cfg)
        {
            cfg.ReceiveEndpoint("order-service", e =>
            {
                e.Consumer<UserAddedConsumer>();
            });
        }
    }
}
