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
            public new Guid Id { get; set; }
            public string Title { get; set; }  = string.Empty;   
            public decimal Price { get; set; }    
            public string Description { get; set; } = string.Empty; 
            public string Category { get; set; } = string.Empty;   
            public string Image { get; set; } = string.Empty;      
            public Guid RatingId { get; set; }
            public virtual Rating? Rating { get; set; }
            public int Amount { get; set; }

        public ICollection<SaleItem>? saleItems { get; set; }

    }
}
