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
            int age = DateTime.Now.Year - Year;

            double baseRatePercent = 5.0; // 5%
            double ageAdjustment = age * 0.15; // +0.15 percentage points per year
            double efficiencyAdjustment = (KmPerKwh > 5) ? -1.0 : 1.0; // -1% or +1%

            return baseRatePercent + ageAdjustment + efficiencyAdjustment;
        }


        // ISellable implementation

        public string GetSalesSummary()
        {
            return $"Electric Car: {Brand} {Model} | {Year}\n" +
                   $"License Plate: {LicensePlate}\n" +
                   $"Milage: {Odometer} KM\n" +
                   $"Price: ${Price}\n" +
                   $"KM/KWH: {KmPerKwh}";
        }
    }
}
