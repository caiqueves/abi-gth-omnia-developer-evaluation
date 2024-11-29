using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IGeolocationRepository
    {
        Task<Geolocation> CreateAsync(Geolocation geolocation, CancellationToken cancellationToken = default);

        Task<Geolocation> UpdateAsync(Geolocation geolocation, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
