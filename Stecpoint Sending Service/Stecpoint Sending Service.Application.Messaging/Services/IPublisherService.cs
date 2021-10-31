using MassTransit;
using System.Threading.Tasks;

namespace MassTransit.Messages.Services
{
    public interface IPublisherService
    {
        Task Publish<T>(T message) where T : class;
    }
}
