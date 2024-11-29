using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{

    public class Filial
    {
        public Guid Id { get; set; }  // ID da filial
        public string Nome { get; set; }  // Nome da filial
        public string Endereco { get; set; }  // Endereço da filial

        // Lista de vendas realizadas nessa filial
        public ICollection<Venda> Vendas { get; set; }
    }

}
