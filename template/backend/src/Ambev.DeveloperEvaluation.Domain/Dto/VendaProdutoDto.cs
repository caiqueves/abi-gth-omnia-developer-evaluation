using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Dto
{
    public class VendaProdutoDto
    {
        public string ProdutoId { get; set; } = string.Empty;

        public int Quantidade { get; set; }
    }
}
