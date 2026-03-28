namespace CarAppGroup8
{
    public class FuelCar : Car, ISellable, IInsurable
    {
        public double TankCapacity { get; private set; }
        public double FuelLevel { get; private set; }
        public double KmPerLiter { get; private set; }

        public FuelCar(string brand, string model, int year, string licensePlate, double tankCapacity, double kmPerLiter)
            : base(brand, model, year, licensePlate)
        {
            TankCapacity = tankCapacity;
            KmPerLiter = kmPerLiter;
            FuelLevel = tankCapacity;
        }

        public override void UpdateEnergyLevel(double km)
        {
            FuelLevel -= km / KmPerLiter;
            if (FuelLevel < 0)
            {
                FuelLevel = 0;
            }
        }

        public void Refuel(double Liters)
        {
            FuelLevel = Math.Min(FuelLevel + Liters, TankCapacity);
        }


        // IInsurable implementation
        public string RegistrationNumber => LicensePlate;

        public double GetInsuranceRate()
        {
            // Simple insurance rate calculation based on car's age and fuel efficiency
            int age = DateTime.Now.Year - Year;
            double baseRate = 500; // Base rate in dollars
            double ageFactor = age * 20; // Increase rate by $20 for each year of age
            double efficiencyFactor = (KmPerLiter > 15) ? -50 : 50; // Discount for efficient cars, surcharge for inefficient ones
            return baseRate + ageFactor + efficiencyFactor;

        }


        // ISellable implementation
        public double Price { get; }

        public string GetSalesSummary()
        {
            return $"Fuel Car: {Brand} {Model} | {Year},\n" +
                   $"License Plate: {LicensePlate}\n" +
                   $"Milage: {Odometer} KM\n" +
                   $"Price: ${Price}\n" +
                   $"KM/L: {KmPerLiter}";
        }
    }
}
