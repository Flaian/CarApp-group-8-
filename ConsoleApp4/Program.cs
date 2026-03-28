namespace CarAppGroup8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Test Interfaces
            FuelCar fuelCar = new FuelCar("Mazda", "3", 2019, "DW60547", 56000, 30000, 50.0, 19.0);
            ElectricCar electricCar = new ElectricCar("Tesla", "Model 3", 2022, "EL99999", 25000, 40000, 75.0, 6.5);
            House house1 = new House("123 Main St", 1990, 350000, "HS12345");

            List<ISellable> sellableCars = new List<ISellable> { fuelCar, electricCar, house1 };

            List<IInsurable> insurableCars = new List<IInsurable> { fuelCar, electricCar, house1 };

            fuelCar.ToggleEngine();
            electricCar.ToggleEngine();

            Trip trip1 = new Trip(fuelCar, 120, DateTime.Now, DateTime.Now.AddHours(2));
            Trip trip2 = new Trip(electricCar, 60, DateTime.Now, DateTime.Now.AddHours(1));

            fuelCar.Drive(trip1);
            electricCar.Drive(trip2);

            // Test ISellable
            Console.WriteLine("=== Interface Test - Sellable ===");

            foreach (ISellable car in sellableCars)
            {
                Console.WriteLine(car.GetSalesSummary());
                Console.WriteLine();
            }

            double totalValue = 0;

            foreach (ISellable s in sellableCars)
            {
                if (s is Car car)
                {
                    totalValue += car.Price;
                }
            }
            Console.WriteLine($"Total Value of all cars: ${totalValue:N0}");
            Console.WriteLine();


            // Test IInsurable
            Console.WriteLine("=== Interface Test - Insurable ===");

            foreach (IInsurable i in insurableCars)
            {
                Console.WriteLine($"{i.RegistrationNumber}: {i.GetInsuranceRate():F1}%");
            }

            Console.WriteLine();

            // 2. Test Polymorphism
            /*List<Car> cars = new List<Car>();

            cars.Add(new FuelCar("Mazda", "3", 2019, "DW60547", 56000, 30000, 50.0, 19.0));
            cars.Add(new ElectricCar("Tesla", "Model 3", 2022, "EL99999", 25000, 40000, 75.0, 6.5));

            Console.WriteLine("=== Polymorphism TEST ===");

            foreach (Car car in cars)
            {
                car.ToggleEngine();
                Trip trip = new Trip(car, 60, DateTime.Now, DateTime.Now.AddHours(1));
                car.Drive(trip);

                Console.WriteLine($"{car.Brand} {car.Model}");
                Console.WriteLine($"Odometer: {car.Odometer} km");

                if (car is FuelCar fuel)
                {
                    Console.WriteLine($"Fuel Level: {fuel.FuelLevel:F1}\n");
                }
                if (car is ElectricCar electric)
                {
                    Console.WriteLine($"Battery Level: {electric.BatteryLevel:F1}\n");
                }
            }*/

            Console.ReadKey();
        }
    }
}