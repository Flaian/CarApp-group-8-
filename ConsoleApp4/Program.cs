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


            // 2. Test Polymorphism
            List<Car> cars = new List<Car>();

            cars.Add(new FuelCar("Mazda", "3", 2019, "DW60547", 50.0, 19.0));
            cars.Add(new ElectricCar("Tesla", "Model 3", 2022, "EL99999", 75.0, 6.5));

            Console.WriteLine("=== Polymorphism TEST ===");

            foreach (var car in cars)
            {
                car.TurnOnEngine();
                Trip trip = new Trip(car, 60, DateTime.Now, DateTime.Now.AddHours(1));
                car.Drive(trip);

                Console.WriteLine($"{car.Brand} {car.Model}");
                Console.WriteLine($"Odometer: {car.Odometer} km\n");
            }

            Console.ReadKey();
        }
    }
}