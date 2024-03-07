using Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfraestructure.Persistence.Configuration;

public class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
{
    public void Configure(EntityTypeBuilder<Vehiculo> builder)
    {
        builder.ToTable("Vehiculos");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasConversion(
            vehiculoId => vehiculoId.Value,
            value => new VehiculoId(value)
        );

        builder.Property(c=> c.Plates).HasMaxLength(50);
        builder.HasIndex(c=> c.Plates).IsUnique();

        builder.Property(c=> c.Brand).HasMaxLength(50);
        builder.Property(c=> c.Model).HasMaxLength(50);
        builder.Property(c=> c.Year).HasMaxLength(50); 
        builder.Property(c=> c.Price).HasMaxLength(50);   
    }
}
