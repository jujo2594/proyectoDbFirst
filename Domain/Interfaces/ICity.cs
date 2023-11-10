using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces
{
    public interface ICity : IGenericRepository<City>
    {
        Task<IEnumerable<City>> getCustomerByCity(string name);
    }
}