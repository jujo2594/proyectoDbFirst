using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
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

    }
}