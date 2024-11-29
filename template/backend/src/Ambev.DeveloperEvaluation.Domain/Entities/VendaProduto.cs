using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
   
    public class VendaProduto
    {
        public Guid VendaId { get; set; }  // Chave estrangeira para a venda
        public Venda Venda { get; set; }

        public Guid ProdutoId { get; set; }  // Chave estrangeira para o produto
        public Product? Produto { get; set; }

        public int Quantidade { get; set; }  // Quantidade do produto na venda
        public decimal PrecoUnitario { get; set; }  // Preço unitário na venda
        public decimal Desconto { get; set; }  // Desconto aplicado no item
        public decimal ValorTotal { get; set; }  // Valor total para esse item (Quantidade * PreçoUnitario - Desconto)
    }

}
