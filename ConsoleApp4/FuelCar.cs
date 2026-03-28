namespace CarAppGroup8
{
    public class FuelCar : Car, ISellable, IInsurable
    {
        public double TankCapacity { get; private set; }
        public double FuelLevel { get; private set; }
        public double KmPerLiter { get; private set; }

        public FuelCar(string brand, string model, int year, string licensePlate, double odometer, double price, double tankCapacity, double kmPerLiter)
            : base(brand, model, year, licensePlate, odometer, price)
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
            int age = DateTime.Now.Year - Year;

            double rate = 0.05; // 5%

            rate += age * 0.002; // +0.2% per year
            rate += (KmPerLiter > 15) ? -0.01 : 0.01; // -1% or +1%

            return rate * 100;

        }


        // ISellable implementation

        public string GetSalesSummary()
        {
            return $"Fuel Car: {Brand} {Model} | {Year}\n" +
                   $"License Plate: {LicensePlate}\n" +
                   $"Milage: {Odometer} KM\n" +
                   $"Price: ${Price}\n" +
                   $"KM/L: {KmPerLiter}";
        }
    }
}
