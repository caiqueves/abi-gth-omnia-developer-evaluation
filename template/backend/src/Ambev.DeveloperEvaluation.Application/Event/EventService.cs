using Ambev.DeveloperEvaluation.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Event
{
    public class EventService
    {
        private readonly IEventPublisher _eventPublisher;

        public EventService(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }

        public void PublishEvent(string message)
        {
            _eventPublisher.PublishEvent(message);
        }
    }
}
