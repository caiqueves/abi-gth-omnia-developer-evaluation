using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public new Guid Id { get; private set; }
    public Guid SaleNumber { get; private set; }
    public DateTime SaleDate { get; private set; }
    public Guid CustomerId { get; private set; }
    public decimal TotalAmount { get; private set; }
    public Guid BranchId { get; private set; }
    public bool IsCancelled { get; private set; }

    private readonly List<SaleItem> _items = new();
    public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();

    protected Sale() { }

    public Sale(DateTime saleDate, Guid customerId, Guid branchId)
    {
        Id = Guid.NewGuid();
        SaleNumber = Guid.NewGuid();
        SaleDate = saleDate;
        CustomerId = customerId;
        BranchId = branchId;
        IsCancelled = false;
    }

    public void UpdateHeader(DateTime saleDate, Guid customerId, Guid branchId)
    {
        SaleDate = saleDate;
        CustomerId = customerId;
        BranchId = branchId;
    }

    public void AddItem(string productName, int quantity, decimal unitPrice)
    {
        if (quantity > 20)
            throw new InvalidOperationException("Cannot sell more than 20 identical items.");

        var discount = CalculateDiscount(quantity);
        var total = quantity * unitPrice * (1 - discount);

        var item = new SaleItem(Guid.Empty, productName, quantity, unitPrice, discount, total, false);
        _items.Add(item);

        RecalculateTotal();
    }

    public void UpdateItem(Guid itemId, string productName, int quantity, decimal unitPrice)
    {
        var existingItem = _items.FirstOrDefault(i => i.Id == itemId);
        if (existingItem == null)
            throw new KeyNotFoundException($"Item {itemId} not found");

        if (quantity > 20)
            throw new InvalidOperationException("Cannot sell more than 20 identical items.");

        var discount = CalculateDiscount(quantity);
        var total = quantity * unitPrice * (1 - discount);

        existingItem.Update(existingItem.Id, productName, quantity, unitPrice, discount, total, existingItem.IsCancelled);

        RecalculateTotal();
    }

    public void CancelItem(Guid itemId)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item != null)
        {
            item.Cancel();
            RecalculateTotal();
        }
    }

    public void Cancel()
    {
        IsCancelled = true;
        foreach (var item in _items)
        {
            item.Cancel();
        }
        RecalculateTotal();
    }

    private void RecalculateTotal()
    {
        TotalAmount = _items
            .Where(i => !i.IsCancelled)
            .Sum(i => i.Total);
    }

    private decimal CalculateDiscount(int quantity)
    {
        if (quantity >= 10 && quantity <= 20)
            return 0.20m;
        if (quantity >= 4)
            return 0.10m;
        return 0m;
    }
}
