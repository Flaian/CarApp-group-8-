using System;

public class ElectricCar : Car, ISellable, IInsurable
{
	public double BatteryCapacity { get; private set; }
	public double BatteryLevel { get; private set; }
    public double KmPrKwh { get; private set; }
	public double Price { get; private set; }
    public string RegistrationNumber => LicensePlate;

    // Constructor
    public ElectricCar(string brand, string model, int year, string licensePlate, double price, double batteryCapacity, double kmPrKwh)
		: base(brand, model, year, licensePlate)
	{
		Price = price;
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

    // Method - GetSalesSummary()
    public string GetSalesSummary()
    {
		return $"{Brand} {Model} ({Year}) - {Odometer} km - Electric car";
    }

    // Method - GetInsuranceRate()
    public double GetInsuranceRate()
    {
		return 0.04; // 4%
    }
}
