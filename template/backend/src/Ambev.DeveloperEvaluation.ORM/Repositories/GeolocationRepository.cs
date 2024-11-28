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

        public async Task<Geolocation> UpdateAsync(Geolocation geolocation, CancellationToken cancellationToken = default)
        {
            var existingGeolocation = await _context.Geolocation.FindAsync(new object[] { geolocation.Id }, cancellationToken);

            if (existingGeolocation == null)
            {
                return new Geolocation { };
            }

            existingGeolocation.Lat = geolocation.Lat;
            existingGeolocation.Long = geolocation.Long;

            _context.Geolocation.Update(existingGeolocation);

            try
            {
                //await _context.SaveChangesAsync(cancellationToken);
                return existingGeolocation;
            }
            catch (Exception)
            {

                return new Geolocation { };
            }
        }
    }
}
