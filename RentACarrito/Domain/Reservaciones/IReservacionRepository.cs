namespace Domain.Reservaciones;

public interface IReservacionRepository
{
<<<<<<< HEAD
    Task<Reservacion?> GetByIdAsync(ReservacionId id);
    Task Add(Reservacion reservacion);

=======
    Task<List<Reservacion>> GetAll();
    Task<Reservacion?> GetByIdAsync(ReservacionId id);
    Task<bool> ExistsAsync(ReservacionId id);
    void Add(Reservacion reservacion);
    void Update(Reservacion reservacion);
    void Delete(Reservacion reservacion);
>>>>>>> 050147275a1e13b90fea4c8c629150b243c215ea
}