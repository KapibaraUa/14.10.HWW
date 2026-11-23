using System;

namespace UniversityApp;

public class Address
{
    private string _city = String.Empty;
    private string _street = String.Empty;
    private string _building = String.Empty;

    public string City
    {
        get { return _city; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Місто не може бути порожнім.");
            _city = value;
        }
    }

    public string Street
    {
        get { return _street; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Вулиця не може бути порожньою.");
            _street = value;
        }
    }

    public string Building
    {
        get { return _building; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Номер будівлі не може бути порожнім.");
            _building = value;
        }
    }

    public Address()
    {
        City = "Невідомо";
        Street = "Невідомо";
        Building = "0";
    }

    public Address(string city, string street, string building)
    {
        City = city;
        Street = street;
        Building = building;
    }

    public void DisplayInfo()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"м. {City}, вул. {Street}, {Building}";
    }
}