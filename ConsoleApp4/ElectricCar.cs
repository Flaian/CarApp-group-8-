using System;

public class ElectricCar : Car
{
	public double BatteryCapacity { get; private set; }
	public double BatteryLevel { get; private set; }
    public double KmPrKwh { get; private set; }

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
}
