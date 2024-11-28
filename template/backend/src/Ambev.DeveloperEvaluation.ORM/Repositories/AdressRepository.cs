﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
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

    }
}