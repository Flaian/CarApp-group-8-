namespace CarAppGroup8
{
    internal class ElectricCar : Car
    {
        public double BatteryCapacity { get; private set; }
        public double BatteryLevel { get; private set; }
        public double KmPerKwh { get; private set; }

        public ElectricCar(string brand, string model, int year, string licensePlate, double batteryCapacity, double kmPerKwh)
            : base(brand, model, year, licensePlate)
        {
            BatteryCapacity = batteryCapacity;
            BatteryLevel = kmPerKwh;
            BatteryLevel = batteryCapacity;
        }

        public override void UpdateEnergyLevel(double km)
        {
            BatteryLevel -= km / KmPerKwh;
            if (BatteryLevel < 0)
            {
                BatteryLevel = 0;
            }
        }

        public void Charge(double kwh)
        {
            BatteryLevel = Math.Min(BatteryLevel + kwh, BatteryCapacity);
        }
    }
}
