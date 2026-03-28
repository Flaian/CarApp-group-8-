namespace CarAppGroup8
{
    internal class ElectricCar : Car, ISellable, IInsurable
    {
        public double BatteryCapacity { get; private set; }
        public double BatteryLevel { get; private set; }
        public double KmPerKwh { get; private set; }


        public ElectricCar(string brand, string model, int year, string licensePlate, double odometer, double price, double batteryCapacity, double kmPerKwh)
            : base(brand, model, year, licensePlate, odometer, price)
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
            // Simple insurance rate calculation based on car's age and energy efficiency
            int age = DateTime.Now.Year - Year;
            double baseRate = 400; // Base rate in dollars
            double ageFactor = age * 15; // Increase rate by $15 for each year of age
            double efficiencyFactor = (KmPerKwh > 5) ? -40 : 40; // Discount for efficient cars, surcharge for inefficient ones
            return baseRate + ageFactor + efficiencyFactor;
        }


        // ISellable implementation

        public string GetSalesSummary()
        {
            return $"Electric Car: {Brand} {Model} | {Year},\n" +
                   $"License Plate: {LicensePlate}\n" +
                   $"Milage: {Odometer} KM\n" +
                   $"Price: ${Price}\n" +
                   $"KM/KWH: {KmPerKwh}";
        }
    }
}
