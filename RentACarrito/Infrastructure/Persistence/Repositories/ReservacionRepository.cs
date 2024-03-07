using Domain.Reservaciones;
using Microsoft.EntityFrameworkCore;

namespace Insfraestructure.Persistence.Repositories;

public class ReservacionRepository : IReservacionRepository
{
    private readonly ApplicationDbContext _context;

    public ReservacionRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentException(nameof(context));
    }

    public async Task Add(Reservacion reservacion) => await _context.Reservaciones.AddAsync(reservacion);

    public async Task<Reservacion?> GetByIdAsinc(ReservacionId id) => await _context.Reservaciones.SingleOrDefaultAsync(c => c.Id == id);

}