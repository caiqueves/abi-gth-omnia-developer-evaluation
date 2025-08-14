using Ambev.DeveloperEvaluation.Application.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Services;

public class SaleCreatedEventService : ISaleCreatedEventService
{
    private readonly IRabbitMqEventPublisher _rabbitMqEventPublisher;

    public SaleCreatedEventService(IRabbitMqEventPublisher rabbitMqEventPublisher)
    {
        _rabbitMqEventPublisher = rabbitMqEventPublisher;
    }

    public void PublishSaleCreatedEvent(SaleCreatedEvent saleCreatedEvent)
    {
        _rabbitMqEventPublisher.PublishEvent(JsonConvert.SerializeObject(saleCreatedEvent), "SaleCreated");
    }
}
