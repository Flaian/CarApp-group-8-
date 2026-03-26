using System;

public class FuelCar : Car, ISellable, IInsurable
{
	public double TankCapacity { get; private set; }
    public double FuelLevel { get; private set; }
    public double KmPrLiter { get; private set; }
	public double Price => CalculatePrice();

    // Constructor
    public FuelCar(string brand, string model, int year, string licensePlate, double tankCapacity, double kmPrLiter)
		: base(brand, model, year, licensePlate)
	{
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

	// Method - CalculatePrice()
	public double CalculatePrice()
	{
		// Just a simplistic example
		return 100000 - (Odometer * 0.5);
	}

	// Method - GetInsuranceRate()
	public double GetInsuranceRate()
	{
		// Simplistic example
		return 5000 + (Odometer * 0.02);
	}
}
