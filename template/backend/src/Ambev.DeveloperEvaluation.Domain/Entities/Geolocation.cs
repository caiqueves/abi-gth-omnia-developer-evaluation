using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Geolocation: BaseEntity
    {
        public Guid Id { get; set; }
        public string Lat { get; set; } = string.Empty;
        public string Long { get; set; } = string.Empty;
    }
}
