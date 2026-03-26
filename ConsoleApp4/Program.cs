namespace CarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            cars.Add(new FuelCar("Hyundai", "i10", 2012, "EC36063", 35.0, 20.0));
            cars.Add(new ElectricCar("Tesla", "Model 3", 2022, "EL99999", 75.0, 6.5));
            cars.Add(new FuelCar("Hyundai", "i10", 2022, "CU26620", 35.0, 24.0));

            foreach (Car car in cars)
            {
                car.ToggleEngine();
                Trip trip = new Trip(car, 60, DateTime.Now, DateTime.Now.AddHours(1));
                car.Drive(trip);
                Console.WriteLine($"{car.Brand} odometer: {car.Odometer} km");
                car.ToggleEngine();
            }
        }
    }
}