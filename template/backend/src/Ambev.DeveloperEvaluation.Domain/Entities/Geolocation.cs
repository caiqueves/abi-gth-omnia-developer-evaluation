using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Geolocation: BaseEntity
    {
        public new Guid Id { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
    }
}
