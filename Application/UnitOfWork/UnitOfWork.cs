using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ICity _cities;
        private ICountry _countries;
        private ICustomer _customers;
        private IPersonType _personTypes;
        private IState _states;
        private readonly ejemploDbContext _context;
        public UnitOfWork(ejemploDbContext context)
        {
            _context = context;
        }
        public ICity Cities
        {
            get
            {
                if (_cities == null)
                {
                    _cities = new CityRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _cities;
            }
        }

        public ICountry Countries
        {
            get
            {
                if (_countries == null)
                {
                    _countries = new CountryRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _countries;
            }
        }

        public ICustomer Customers
        {
            get
            {
                if (_customers == null)
                {
                    _customers = new CustomerRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _customers;
            }
        }

        public IPersonType PersonTypes
        {
            get
            {
                if (_personTypes == null)
                {
                    _personTypes = new PersonTypeRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _personTypes;
            }
        }

        public IState States
        {
            get
            {
                if (_states == null)
                {
                    _states = new StateRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _states;
            }
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}