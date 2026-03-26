namespace CarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Existing cars - can change/add/remove as wanted/needed
            List<ISellable> forSale = new List<ISellable>();
            List<IInsurable> insured = new List<IInsurable>();

            List<Car> cars = new List<Car>();
            cars.Add(new FuelCar("Hyundai", "i10", 2012, "EC36063", 35000, 35.0, 20.0));
            cars.Add(new ElectricCar("Tesla", "Model 3", 2022, "EL99999", 400000, 75.0, 6.5));
            cars.Add(new FuelCar("Hyundai", "i10", 2022, "CU26620", 38000, 35.0, 24.0));

            // Driving a trip and adding cars to ISellable list
            foreach (Car car in cars)
            {
                car.ToggleEngine();
                Trip trip = new Trip(car, 60, DateTime.Now, DateTime.Now.AddHours(1));
                car.Drive(trip);
                car.ToggleEngine();

                if (car is ISellable sellable)
                {
                    forSale.Add(sellable);
                }

                if (car is IInsurable insurable)
                {
                    insured.Add(insurable);
                }
            }

            // Getting a sales summary for all cars on list and adding total value
            double total = 0;
            foreach (ISellable s in forSale)
            {
                Console.WriteLine(s.GetSalesSummary());
                total += s.Price;
            }

            Console.WriteLine($"\nTotal value: {total:N1} DKK");

            // Getting the insurance rate for each car as well as the average rate
            int totalCars = 0;
            double avgInsRate = 0;
            foreach (IInsurable i in insured)
            {
                Console.WriteLine($"{i.RegistrationNumber}: {i.GetInsuranceRate():F4}%");
                totalCars += 1;
                avgInsRate += i.GetInsuranceRate();
            }

            Console.WriteLine($"\nAverage insurance rate across all {totalCars} cars: {avgInsRate / totalCars:F4}");
        }
    }
}