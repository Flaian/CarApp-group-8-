namespace CarAppGroup8
{
    public class ElectricCar : Car
    {
        public double BatteryCapacity { get; private set; }
        public double KmPerKwh { get; private set; }

        public ElectricCar(string brand, string model, int year, string licensePlate, double batteryCapacity, double kmPerKwh)
            : base(brand, model, year, licensePlate)
        {
            BatteryCapacity = batteryCapacity;
            KmPerKwh = kmPerKwh;
        }

        public override string ToString()
        {
            return $"ElectricCar, {Brand}, {Model}, {Year}, {LicensePlate}, {BatteryCapacity}, {KmPerKwh}";
        }

        public static ElectricCar FromString(string data)
        {
            string[] parts = data.Split(',');
            return new ElectricCar(
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
