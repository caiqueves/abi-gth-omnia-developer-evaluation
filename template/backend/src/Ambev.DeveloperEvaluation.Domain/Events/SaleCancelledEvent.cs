using Ambev.DeveloperEvaluation.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleCancelledEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public Guid? BranchId { get; }
        public decimal TotalAmount { get; }
        public DateTime SaleDate { get; }

        public List<SaleItemDto> Items { get; }

        public string Mensagem { get; }

        // Construtor
        public SaleCancelledEvent(Guid id, Guid customerId, Guid? branchId, decimal totalAmount, DateTime saleDate, List<SaleItemDto> items, string mensagem)
        {
            Id = id;
            CustomerId = customerId;
            BranchId = branchId;
            TotalAmount = totalAmount;
            SaleDate = saleDate;
            Items = items;
            Mensagem = mensagem;
        }
    }

}
