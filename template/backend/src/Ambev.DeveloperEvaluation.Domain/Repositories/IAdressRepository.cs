﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IAdressRepository
    {
        Task<Address> CreateAsync(Address address, CancellationToken cancellationToken = default);
    }
}