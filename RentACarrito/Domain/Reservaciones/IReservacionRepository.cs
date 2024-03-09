namespace Domain.Reservaciones;

public interface IReservacionRepository
{

   Task<List<Reservacion>> GetAll();
    Task<Reservacion?> GetByIdAsync(ReservacionId id);
    Task<bool> ExistsAsync(ReservacionId id);
    void Add(Reservacion reservacion);
    void Update(Reservacion reservacion);
    void Delete(Reservacion reservacion);

}