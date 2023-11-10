using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repositories
{
    public class StateRepository : GenericRepository<State>, IState
    {
        private readonly ejemploDbContext _context;

        public StateRepository(ejemploDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<State> GetCityByNameState(string state)
        {
            return await _context.States.Where(_state => _state.Name.Trim().ToLower() == state.Trim().ToLower())
            .Include(p => p.Cities)
            .FirstAsync();
        }
    }
}