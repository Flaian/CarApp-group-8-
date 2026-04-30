namespace CarApp.Core.Models
{
    public class ElectricCar : Car
    {
        public double BatteryCapacity { get; set; }
        public double BatteryLevel { get; set; }
        public double KmPerKwh { get; set; }
        public double Price { get; set; }

        public ElectricCar(string brand, string model, int year, string licensePlate, double batteryCapacity, double kmPerKwh, double odometer)
            : base(brand, model, year, licensePlate, odometer)
        {
            BatteryCapacity = batteryCapacity;
            KmPerKwh = kmPerKwh;
        }

        public override string ToString()
        {
            return $"ElectricCar, {Brand}, {Model}, {Year}, {LicensePlate}, {BatteryCapacity}, {KmPerKwh}, {Odometer}";
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
                double.Parse(parts[6].Trim()),
                double.Parse(parts[7].Trim())
            );
        }

    }
}
