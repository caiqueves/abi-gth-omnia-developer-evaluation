using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Venda
    {
        public Guid Id { get; set; }  // Número de venda (ID da venda)
        public DateTime DataVenda { get; set; }  // Data da venda
        public decimal ValorTotal { get; set; }  
        public bool Cancelado { get; set; }  

        public Guid ClienteId { get; set; }
        public User? Cliente { get; set; }

        public Guid FilialId { get; set; }
        public Filial? Filial { get; set; }


        public ICollection<VendaProduto>? VendaProdutos { get; set; }
    }

}
