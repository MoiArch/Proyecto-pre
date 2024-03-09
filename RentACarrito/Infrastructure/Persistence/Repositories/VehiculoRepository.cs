
using Domain.Vehiculos;
using Insfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class VehiculoRepository : IVehiculoRepository
{
    private readonly ApplicationDbContext _context;

    public VehiculoRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }


    public void Add(Vehiculo vehiculo) => _context.Vehiculos.Add(vehiculo);
    public void Delete(Vehiculo vehiculo) => _context.Vehiculos.Remove(vehiculo);
    public void Update(Vehiculo vehiculo) => _context.Vehiculos.Update(vehiculo);
    public async Task<bool> ExistsAsync(VehiculoId id) => await _context.Vehiculos.AnyAsync(vehiculo => vehiculo.Id == id);
    public async Task<Vehiculo?> GetByIdAsync(VehiculoId id) => await _context.Vehiculos.SingleOrDefaultAsync(c => c.Id == id);
    public async Task<List<Vehiculo>> GetAll() => await _context.Vehiculos.ToListAsync();
}