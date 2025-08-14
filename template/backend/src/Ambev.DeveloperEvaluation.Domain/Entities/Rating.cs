

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Rating
    {
            public Guid Id { get; set; }
            public decimal Rate { get; set; }  
            public int Count { get; set; }     
    }
}
