using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity
    {
            public Guid Id { get; set; }
            public string Title { get; set; }  = string.Empty;    // O nome do produto
            public decimal Price { get; set; }     // O preço do produto
            public string Description { get; set; } = string.Empty; // A descrição do produto
            public string Category { get; set; } = string.Empty;   // A categoria do produto
            public string Image { get; set; } = string.Empty;      // A URL da imagem do produto
            public Guid RatingId { get; set; }
            public virtual Rating? Rating { get; set; }     // A avaliação do produto, que é um objeto

    }
}
