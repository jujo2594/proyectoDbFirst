using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("customer");

            builder.HasIndex(e => e.IdTipoPersonaFk, "IX_customer_IdTipoPersonaFk");

            builder.HasIndex(e => e.IdcityFk, "IX_customer_IdcityFk");

            builder.Property(e => e.DateRegister).HasColumnName("date_register");
            builder.Property(e => e.Idcustomer)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");

            builder.HasOne(d => d.IdTipoPersonaFkNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.IdTipoPersonaFk)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.IdcityFkNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.IdcityFk)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}