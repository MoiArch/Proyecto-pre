using Domain.Primitives;
using Application.Data;
using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Domain.Vehiculos;
using Domain.Reservaciones;
using MediatR;

namespace Insfrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    private IPublisher _publisher;

    public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base (options)
    {
        _publisher = publisher ?? throw new ArgumentException(nameof(publisher));
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Reservacion> Reservaciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var domainEvents = ChangeTracker.Entries<AggregateRoot>()
        .Select(e => e.Entity)
        .Where(e => e.GetDomainEvents().Any())
        .SelectMany(e => e.GetDomainEvents());

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }

        return result;
    }
}
