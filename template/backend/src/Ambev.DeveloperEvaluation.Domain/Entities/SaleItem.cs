using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

// Domain/Entities/SaleItem.cs
public class SaleItem : BaseEntity
{
    public new Guid Id { get; private set; }
    public string? ProductName { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal DiscountRate { get; private set; }
    public decimal Total { get; private set; }
    public bool IsCancelled { get; private set; }

    protected SaleItem() { }

    public SaleItem(Guid id, string productName, int quantity, decimal unitPrice, decimal discountRate, decimal total, bool isCancelled)
    {
        Id = id == Guid.Empty ? Guid.NewGuid() : id;
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
        DiscountRate = discountRate;
        Total = total;
        IsCancelled = isCancelled;
    }

    public void Cancel()
    {
        IsCancelled = true;
        Total = 0;
    }

    public void Update(Guid id, string productName, int quantity, decimal unitPrice, decimal discountRate, decimal total, bool isCancelled)
    {
        Id = id;
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
        DiscountRate = discountRate;
        Total = total;
        IsCancelled = isCancelled;
    }
}
