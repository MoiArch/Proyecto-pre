using Domain.Reservaciones;
using Insfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Repositories;

public class ReservacionRepository : IReservacionRepository
{
    private readonly ApplicationDbContext _context;

    public ReservacionRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Reservacion reservacion)=> _context.Reservaciones.Add(reservacion);
    public void Delete(Reservacion reservacion) => _context.Reservaciones.Remove(reservacion);
    public void Update(Reservacion reservacion) => _context.Reservaciones.Update(reservacion);
    public async Task<bool> ExistsAsync(ReservacionId id) => await _context.Reservaciones.AnyAsync(reservacion => reservacion.Id == id);
    public async Task<Reservacion?> GetByIdAsync(ReservacionId id) => await _context.Reservaciones.SingleOrDefaultAsync(c => c.Id == id);
    public async Task<List<Reservacion>> GetAll() => await _context.Reservaciones.ToListAsync();
}