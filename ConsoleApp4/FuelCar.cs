namespace CarAppGroup8
{
    public class FuelCar : Car
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
    }
}
