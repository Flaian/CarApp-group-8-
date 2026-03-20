namespace CarAppGroup8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 1. Test individual car types
            FuelCar fuelCar = new FuelCar("Mazda", "3", 2019, "DW60547", 50.0, 19.0);
            ElectricCar electricCar = new ElectricCar("Tesla", "Model 3", 2022, "EL99999", 75.0, 6.5);

            fuelCar.TurnOnEngine();
            electricCar.TurnOnEngine();

            Trip trip1 = new Trip(fuelCar, 120, DateTime.Now, DateTime.Now.AddHours(2));
            Trip trip2 = new Trip(electricCar, 60, DateTime.Now, DateTime.Now.AddHours(1));

            fuelCar.Drive(trip1);
            electricCar.Drive(trip2);

            Console.WriteLine("=== Individual test ===");
            Console.WriteLine($"FuelCar odometer: {fuelCar.Odometer} km");
            Console.WriteLine($"Fuel level: {fuelCar.FuelLevel:F1} L");
            Console.WriteLine();
            Console.WriteLine($"ElectricCar odometer: {electricCar.Odometer} km");
            Console.WriteLine($"Battery level: {electricCar.BatteryLevel:F1} kWh");

            Console.WriteLine();
        }
    }
}