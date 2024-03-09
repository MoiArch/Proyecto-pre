using System.Globalization;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Customers;

public sealed class Customer : AggregateRoot
{
    private CustomerId customerId;
    private PhoneNumber phoneNumber;
    private Address address;
    private bool v;
    private CustomerId customerId1;
    private PhoneNumber phoneNumber1;
    private Address address1;

    public Customer(CustomerId customerId1, string name, string lastName, string email, DuiNumber duiNumber, PhoneNumber phoneNumber1, Address address1, bool v)
    {
        this.customerId1 = customerId1;
        Name = name;
        LastName = lastName;
        Email = email;
        DuiNumber = duiNumber;
        this.phoneNumber1 = phoneNumber1;
        this.address1 = address1;
        this.v = v;
    }

    private Customer()
    {
    }

    public CustomerId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string FullName => $"{Name} {LastName}";
    public string Email { get; private set; } = string.Empty;
    public DuiNumber DuiNumber { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Address Address { get; private set; }
    public bool Active {get; private set;}
    public static Customer UpdateCustomer(Guid id, string name, string lastName, string email,DuiNumber duiNumber, PhoneNumber phoneNumber, Address address, bool active)
    {
        return new Customer(new CustomerId(id), name, lastName, email, duiNumber, phoneNumber, address, active);
    }
}