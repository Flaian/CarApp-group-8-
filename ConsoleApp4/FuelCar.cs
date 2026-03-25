using System;

public class FuelCar : Car
{
	public double tankCapacity;
	public double fuelLevel;
	public double kmPrLiter;

	// Constructor
	public FuelCar(string brand, string model, int year, string licensePlate, double tankcapacity, double fuellevel, double kmprliter)
		: base(brand, model, year, licensePlate)
	{
        tankCapacity = tankcapacity;
        fuelLevel = fuellevel;
        kmPrLiter = kmprliter;
	}

	// Simple properties
	public double TankCapacity
	{
		get;
		private set;
	}

	public double FuelLevel
	{
		get;
		private set;
	}

	public double KmPrLiter
	{
		get;
		private set;
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
}
