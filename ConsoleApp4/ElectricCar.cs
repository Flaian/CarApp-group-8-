namespace CarAppGroup8
{
    internal class ElectricCar : Car, ISellable, IInsurable
    {
        public double BatteryCapacity { get; private set; }
        public double BatteryLevel { get; private set; }
        public double KmPerKwh { get; private set; }


        public ElectricCar(string brand, string model, int year, string licensePlate, double batteryCapacity, double kmPerKwh)
            : base(brand, model, year, licensePlate)
        {
            BatteryCapacity = batteryCapacity;
            KmPerKwh = kmPerKwh;
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


        // IInsurable implementation
        public string RegistrationNumber => LicensePlate;

        public double GetInsuranceRate()
        {
            return 0.05;
        }


        // ISellable implementation
        public double Price { get; }

        public string GetSalesSummary()
        {
            return $"Fuel Car: {Brand} {Model} | {Year},\n" +
                   $"License Plate: {LicensePlate}\n" +
                   $"Milage: {Odometer} KM\n" +
                   $"Price: ${Price}\n" +
                   $"KM/KWH: {KmPerKwh}";
        }
    }
}
