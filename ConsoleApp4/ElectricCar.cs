using System;

public class ElectricCar : Car, ISellable, IInsurable
{
	public double BatteryCapacity { get; private set; }
	public double BatteryLevel { get; private set; }
    public double KmPrKwh { get; private set; }
	public double Price => CalculatePrice();

    // Constructor
    public ElectricCar(string brand, string model, int year, string licensePlate, double batteryCapacity, double kmPrKwh)
		: base(brand, model, year, licensePlate)
	{
		BatteryCapacity = batteryCapacity;
		BatteryLevel = batteryCapacity;
		KmPrKwh = kmPrKwh;
	}

	// Override of UpdateEnergyLevel()
	public override void UpdateEnergyLevel(double km)
	{
		BatteryLevel -= km / KmPrKwh;
		if (BatteryLevel < 0)
		{
			BatteryLevel = 0;
		}
	}

	// Method - Charge()
	public void Charge(double kwh)
	{
		BatteryLevel = Math.Min(BatteryLevel + kwh, BatteryCapacity);
	}

    // Method - CalculatePrice()
    public double CalculatePrice()
    {
        // Just a simplistic example - Electric cars keep value better than fuel cars
        return 150000 - (Odometer * 0.3);
    }

    // Method - GetInsuranceRate()
    public double GetInsuranceRate()
    {
        // Simplistic example - different risk profile
        return 4000 + (Odometer * 0.015);
    }
}
