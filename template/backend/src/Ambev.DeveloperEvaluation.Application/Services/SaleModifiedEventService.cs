using Ambev.DeveloperEvaluation.Application.Interfaces;
using Ambev.DeveloperEvaluation.Application.Services;
using Ambev.DeveloperEvaluation.Domain.Events;
using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.Application.Event
{
    public class SaleModifiedEventService: ISaleModifiedEventService
    {
        private readonly IRabbitMqEventPublisher _rabbitMqEventPublisher;

        public SaleModifiedEventService(IRabbitMqEventPublisher rabbitMqEventPublisher)
        {
            _rabbitMqEventPublisher = rabbitMqEventPublisher;
        }


        public void PublishSaleModifiedEvent(SaleModifiedEvent saleModifiedEvent)
        {
            _rabbitMqEventPublisher.PublishEvent(JsonConvert.SerializeObject(saleModifiedEvent), "SaleModified");
        }

    }
}
