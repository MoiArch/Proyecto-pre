using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Customers;

public sealed class Customer : AggregateRoot
{
    public Customer(CustomerId id, string name, string lastName, string email, DuiNumber duiNumber,
    PhoneNumber phoneNumber, Address address, bool active)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Email = email;
        DuiNumber = duiNumber;
        PhoneNumber = phoneNumber;
        Address = address;
        Active = active;
    }

    private Customer()
    {

    }

    public CustomerId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{Name} {LastName}";
    public string Email { get; private set; } = string.Empty;
    public DuiNumber DuiNumber{ get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Address Address { get; private set; }
    public bool Active { get; private set; }

    public static Customer UpdateCustomer(Guid id, string name, string lastName, string email,DuiNumber duiNumber, PhoneNumber phoneNumber, Address address, bool active)
    {
        return new Customer(new CustomerId(id), name, lastName, email,duiNumber, phoneNumber, address, active);
    }
}