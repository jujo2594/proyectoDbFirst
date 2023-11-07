using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Data;

public partial class ejemploDbContext : DbContext
{
    public ejemploDbContext()
    {
    }

    public ejemploDbContext(DbContextOptions<ejemploDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<PersonType> PersonTypes { get; set; }
    public virtual DbSet<State> States { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
