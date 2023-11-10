using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using iText.Svg.Renderers;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountry
    {
        private readonly ejemploDbContext _context;

        public CountryRepository(ejemploDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Countries
                        // .Include(c => c.States)
                        // .ThenInclude(c => c.Cities)
                        .ToListAsync();
        }

        public async Task<Country> getCountryByName(string country)
        {
            return await _context.Countries.Where(_country => _country.Name.Trim().ToLower() == country.Trim().ToLower())
            .FirstAsync();
        }

        public async Task<IEnumerable<Country>> getCountryByNameState(string country)
        {
            return await _context.Countries.Where(_country => _country.Name.Trim().ToLower() == country.Trim().ToLower())
            .Include(c => c.States) 
            .ThenInclude(j =>j.Cities)
            .ToListAsync(); 
        }
    }
}