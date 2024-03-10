using Domain.Reservaciones;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfraestructure.Persistence.Configuration;

public class ReservacionConfiguration : IEntityTypeConfiguration<Reservacion>
{
    public void Configure(EntityTypeBuilder<Reservacion> builder)
    {
        builder.ToTable("Reservaciones");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasConversion(
            reservacionId => reservacionId.Value,
            value => new ReservacionId(value)
        );

        builder.Property(c=> c.Name).HasMaxLength(50);
        builder.Property(c=> c.LastName).HasMaxLength(50);
        builder.Property(c=> c.Email).HasMaxLength(50);  
        builder.HasIndex(c=> c.Email).IsUnique();
       
        builder.Property(c => c.PhoneNumber).HasConversion(
            phoneNumber => phoneNumber.Value,
            value => PhoneNumber.Create(value)!);

        builder.Property(c=> c.Date).HasMaxLength(50);
        
        builder.OwnsOne (c => c.Vehicle, vehiclebuilder =>{
            vehiclebuilder.Property(a => a.Plates).HasMaxLength(25);
            vehiclebuilder.Property(a => a.Brand).HasMaxLength(25);
            vehiclebuilder.Property(a => a.Model).HasMaxLength(25);
            vehiclebuilder.Property(a => a.Year).HasMaxLength(50);
            vehiclebuilder.Property(a => a.Price).HasMaxLength(50);
        });

    }
}
