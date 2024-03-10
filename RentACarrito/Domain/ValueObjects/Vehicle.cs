namespace Domain.ValueObjects;

public partial record Vehicle
{
    public Vehicle(string plates, string brand,string model, string year, string price)
    {
        Plates = plates;
        Brand = brand;
        Model =model;
        Year = year;
        Price = price;
    }
    public string Plates {get; init;}
    public string Brand {get; init;}
    public string Model {get; init;}
    public string Year {get; init;}
    public string Price {get; init;}

    public static Vehicle? Create(string plates, string brand,string model, string year, string price)
    {
        if(string.IsNullOrEmpty(plates) || string.IsNullOrEmpty(brand) ||
        string.IsNullOrEmpty(model)|| string.IsNullOrEmpty(year)|| string.IsNullOrEmpty(price))
        {
            return null;
        }
        return new Vehicle(plates, brand, model, year, price);
    }
}