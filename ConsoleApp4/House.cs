using System;

public class House : ISellable, IInsurable
{
    public string Address { get; }
    public int YearBuilt { get; }
    public double Price { get; }
    public string RegistrationNumber { get; } // Cadastral number

    // Constructor
    public House(string address, int yearBuilt, double price, string cadastralNumber)
    {
        Address = address;
        YearBuilt = yearBuilt;
        Price = price;
        RegistrationNumber = cadastralNumber;
    }

    public string GetSalesSummary()
    {
        return $"{Address}, built in {YearBuilt}, price: {Price:N0} DKK";
    }

    public double GetInsuranceRate()
    {
        return YearBuilt < 1980 ? 1.8 : 1.2; // Older houses are more expensive to insure
    }
}