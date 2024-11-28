using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class GeolocationRepository: IGeolocationRepository
    {
        private readonly DefaultContext _context;

        public GeolocationRepository(DefaultContext context) { _context = context; }


        public async Task<Geolocation> CreateAsync(Geolocation geolocation, CancellationToken cancellationToken = default)
        {
            await _context.Geolocation.AddAsync(geolocation, cancellationToken);
            //await _context.SaveChangesAsync(cancellationToken);
            return geolocation;
        }
    }
}
