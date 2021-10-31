using MassTransit;
using Serilog;
using System.Threading.Tasks;

namespace MassTransit.Messages.Services
{
    public class PublisherService: IPublisherService
    {
        private readonly IBus _bus;

        public PublisherService(IBus bus)
        {
            _bus = bus;
        }
        public async Task Publish<T>(T message) where T : class
        {
            await _bus.Publish(message);
            Log.Information("Message was published successfully");
        }
    }
}
