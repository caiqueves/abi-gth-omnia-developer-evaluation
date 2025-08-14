using Ambev.DeveloperEvaluation.Application.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Services
{
    public class SaleCancelledEventService : ISaleCancelledEventService
    {
        private readonly IRabbitMqEventPublisher _rabbitMqEventPublisher;

        public SaleCancelledEventService(IRabbitMqEventPublisher rabbitMqEventPublisher)
        {
            _rabbitMqEventPublisher = rabbitMqEventPublisher;
        }

        public void PublishSaleCancelledEvent(SaleCancelledEvent saleCancelledEvent)
        {
            _rabbitMqEventPublisher.PublishEvent(JsonConvert.SerializeObject(saleCancelledEvent), "SaleCancelled");
        }
    }
}
