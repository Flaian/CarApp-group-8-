namespace CarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double fuelPrice = 14.33;
            double tripPrice = 0;
            bool palindrome = false;

            FuelCar fuelCar = new FuelCar("Hyundai", "i10", 2012, "EC36063", 50.0, 18.0);
            fuelCar.ToggleEngine();

            ElectricCar electricCar = new ElectricCar("Tesla", "Model 3", 2022, "EL99999", 75.0, 6.5);
            electricCar.ToggleEngine();

            Trip trip1 = new Trip(fuelCar, 80, DateTime.Now, DateTime.Now.AddHours(1));
            Trip trip2 = new Trip(electricCar, 60, DateTime.Now, DateTime.Now.AddHours(1));

            fuelCar.Drive(trip1);
            electricCar.Drive(trip2);

            Console.WriteLine($"FuelCar odometer: {fuelCar.Odometer} km");
            Console.WriteLine($"Fuel level: {fuelCar.FuelLevel:F1} L");

            Console.WriteLine($"ElectricCar odometer: {electricCar.Odometer} km");
            Console.WriteLine($"Battery level: {electricCar.BatteryLevel:F1} kWh");

            foreach (Trip trip in fuelCar.GetTrips())
            {
                Console.Write(trip.GetTripDetails());
            }

            List <Trip> tripsByDate = fuelCar.GetTripsByDate(DateTime.Today);

            DateTime start = DateTime.Today;
            DateTime end = DateTime.Today.AddHours(1).AddMinutes(30);

            List<Trip> tripsInTimeInterval = fuelCar.GetTripsInTimeInterval(start, end);
        }
    }
}