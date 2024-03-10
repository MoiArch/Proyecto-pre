using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Reservaciones;

public sealed class Reservacion : AggregateRoot
{
    public Reservacion(ReservacionId id, string name, string lastName, string email, PhoneNumber phoneNumber, string date, Vehicle vehicle)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Date = date;
        Vehicle = vehicle;
    }

     private Reservacion()
    {

    }

    public ReservacionId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public PhoneNumber PhoneNumber { get; private set; }
    public string Date { get; private set; }
    public Vehicle Vehicle { get; private set; }
   
    public static Reservacion UpdateReservacion(Guid id, string name, string lastName, string email, PhoneNumber phoneNumber,string date, Vehicle vehicle)
    {
        return new Reservacion (new ReservacionId(id), name, lastName, email, phoneNumber,date ,vehicle );
    }
}