using Ambev.DeveloperEvaluation.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Interfaces;

public interface ISaleCancelledEventService
{
    void PublishSaleCancelledEvent(SaleCancelledEvent saleModifiedEvent);
}
