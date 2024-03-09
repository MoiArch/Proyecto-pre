using Domain.Vehiculos;

public interface IVehiculoRepository
{
    Task<List<Vehiculo>> GetAll();
    Task<Vehiculo?> GetByIdAsync(VehiculoId id);
    Task<bool> ExistsAsync(VehiculoId id);
    void Add(Vehiculo vehiculo);
    void Update(Vehiculo vehiculo);
    void Delete(Vehiculo vehiculo);
}
