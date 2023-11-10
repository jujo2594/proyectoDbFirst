using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Data;

namespace Application.Repositories
{
    public class CityRepository : GenericRepository<City>, ICity
    {
        private readonly ejemploDbContext _context;
        public CityRepository(ejemploDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _context.Cities
                .Include(c => c.Customers)
                .ToListAsync();
        }   
        public async Task<IEnumerable<City>> getCustomerByCity(string city)
        {
            return await _context.Cities.Where(_city => _city.Name.Trim().ToLower() == city.Trim().ToLower())
            .Include(p => p.Customers)
            .ToListAsync();
        }
    }
}