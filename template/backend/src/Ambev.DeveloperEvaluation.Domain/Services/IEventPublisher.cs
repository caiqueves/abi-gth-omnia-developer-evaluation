
namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public interface IEventPublisher
    {
        void PublishEvent(string eventMessage);
    }
}

