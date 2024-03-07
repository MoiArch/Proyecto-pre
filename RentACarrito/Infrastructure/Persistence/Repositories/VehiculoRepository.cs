using Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;

namespace Insfraestructure.Persistence.Repositories;

public class VehiculoRepository : IVehiculoRepository
{
    private readonly ApplicationDbContext _context;

    public VehiculoRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentException(nameof(context));
    }

    public async Task Add(Vehiculo vehiculo) => await _context.Vehiculos.AddAsync(vehiculo);
 
    public async Task<Vehiculo?> GetByIdAsync(VehiculoId id) => await _context.Vehiculos.SingleOrDefaultAsync(c => c.Id == id);
}