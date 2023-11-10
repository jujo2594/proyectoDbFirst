using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces
{
    public interface ICountry : IGenericRepository<Country>
    {
        Task<Country> getCountryByName(string name);
        Task<IEnumerable<Country>> getCountryByNameState (string name);
    }
}