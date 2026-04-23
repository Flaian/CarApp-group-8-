namespace CarAppGroup8
{
    public class FuelCar : Car
    {
        public double TankCapacity { get; set; }
        public double FuelLevel { get; set; }
        public double KmPerLiter { get; set; }
        public double Price { get; set; }

        public FuelCar(string brand, string model, int year, string licensePlate, double tankCapacity, double kmPerLiter)
            : base(brand, model, year, licensePlate)
        {
            TankCapacity = tankCapacity;
            KmPerLiter = kmPerLiter;
        }


        public override string ToString()
        {
            return $"FuelCar, {Brand}, {Model}, {Year}, {LicensePlate}, {TankCapacity}, {KmPerLiter}, {FuelLevel}, {Price}";
        }


        public static FuelCar FromString(string data)
        {
            string[] parts = data.Split(',');
            return new FuelCar(
                parts[1].Trim(),
                parts[2].Trim(),
                int.Parse(parts[3].Trim()),
                parts[4].Trim(),
                double.Parse(parts[5].Trim()),
                double.Parse(parts[6].Trim())
            );


        }
    }
}
