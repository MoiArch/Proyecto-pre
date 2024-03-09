namespace Domain.Reservaciones;

public interface IReservacionRepository
{
    Task<Reservacion?> GetByIdAsync(ReservacionId id);
    Task Add(Reservacion reservacion);

}