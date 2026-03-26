using System;

public class FuelCar : Car, ISellable, IInsurable
{
	public double TankCapacity { get; private set; }
    public double FuelLevel { get; private set; }
    public double KmPrLiter { get; private set; }
	public double Price { get; private set; }
	public string RegistrationNumber => LicensePlate;

    // Constructor
    public FuelCar(string brand, string model, int year, string licensePlate, double price, double tankCapacity, double kmPrLiter)
		: base(brand, model, year, licensePlate)
	{
		Price = price;
        TankCapacity = tankCapacity;
        FuelLevel = tankCapacity;
        KmPrLiter = kmPrLiter;
	}

	// Override of UpdateEnergyLevel()
	public override void UpdateEnergyLevel(double km)
	{
		FuelLevel -= km / KmPrLiter;
		if (FuelLevel < 0)
		{
			FuelLevel = 0;
		}
	}

	// Method - Refuel()
	public void Refuel(double liters)
	{
		FuelLevel = Math.Min(FuelLevel + liters, TankCapacity);
	}

	// Method - GetSalesSummary()
	public string GetSalesSummary()
	{
		return $"{Brand} {Model} ({Year}) - {Odometer} km - Fuel car";
	}

	// Method - GetInsuranceRate()
	public double GetInsuranceRate()
	{
		// Simplistic example
		return 0.06; // 6%
	}
}
