using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public class CancelSaleResult
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }

    public DateTime Date { get; set; }

    public List<SaleItem>? Product { get; set; }

    public string Mensagem { get; set; } = string.Empty;
}
