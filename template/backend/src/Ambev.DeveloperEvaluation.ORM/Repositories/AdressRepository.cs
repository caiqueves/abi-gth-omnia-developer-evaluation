using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class AdressRepository: IAdressRepository
    {
        private readonly DefaultContext _context;

        public AdressRepository(DefaultContext context)
        {
                _context = context;
        }

        /// <summary>
        /// Creates a new address in the database
        /// </summary>
        /// <param name="address">The address to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created address</returns>
        public async Task<Address> CreateAsync(Address address, CancellationToken cancellationToken = default)
        {
            await _context.Addresss.AddAsync(address, cancellationToken);
            //await _context.SaveChangesAsync(cancellationToken);
            return address;
        }

        public async Task<Address> UpdateAsync(Address address, CancellationToken cancellationToken = default)
        {
            var existingAddress = await _context.Addresss.FindAsync(new object[] { address.Id }, cancellationToken);

            if (existingAddress == null)
            {
                return new Address { };
            }

            existingAddress.City = address.City;
            existingAddress.Street = address.Street;
            existingAddress.Number = address.Number;
            existingAddress.Zipcode = address.Zipcode;

            _context.Addresss.Update(existingAddress);

            try
            {
                ////await _context.SaveChangesAsync(cancellationToken);
                return existingAddress;
            }
            catch (Exception)
            {

                return new Address { };
            }
        }

        public async Task<Address?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Addresss.Where(o => o.Id == id)
                .Include(ads => ads.Geolocation).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var ads = await GetByIdAsync(id, cancellationToken);
            if (ads == null)
                return false;

            _context.Addresss.Remove(ads);
            ////await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
