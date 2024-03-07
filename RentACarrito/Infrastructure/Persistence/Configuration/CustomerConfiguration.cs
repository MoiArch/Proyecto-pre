using Domain.Customers;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfraestructure.Persistence.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasConversion(
            customerId => customerId.Value,
            value => new CustomerId(value)
        );

        builder.Property(c=> c.Name).HasMaxLength(50);
        builder.Property(c=> c.LastName).HasMaxLength(50);
        builder.Property(c=> c.Email).HasMaxLength(50);  
        builder.HasIndex(c=> c.Email).IsUnique();

        builder.Property(c => c.DuiNumber).HasConversion(
            duiNumber => duiNumber.Value,
            value => DuiNumber.Create(value)!);

       
        builder.Property(c => c.PhoneNumber).HasConversion(
            phoneNumber => phoneNumber.Value,
            value => PhoneNumber.Create(value)!);

        builder.OwnsOne (c => c.Address, addressbuilder =>{
            addressbuilder.Property(a => a.Departamento).HasMaxLength(25);
            addressbuilder.Property(a => a.Municipio).HasMaxLength(25);
            addressbuilder.Property(a => a.Distrito).HasMaxLength(25);
            addressbuilder.Property(a => a.Direccion).HasMaxLength(50);
        });

        builder.Property(c=> c.Active);
    }
}
