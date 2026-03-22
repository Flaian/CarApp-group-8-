namespace CarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double fuelPrice = 14.33;
            double tripPrice = 0;
            bool palindrome = false;

            Car car = new Car("Hyundai", "i10", 2012, 'M', 130031, FuelType.Gasoline, false, 18.9, "CS36036");
            car.ToggleEngine();

            List<Trip> trips = new List<Trip>()
            {
                new Trip(car, 50, DateTime.Today, DateTime.Today.AddHours(1)),
                new Trip(car, 30, DateTime.Today, DateTime.Today.AddMinutes(30)),
                new Trip(car, 100, DateTime.Today, DateTime.Today.AddHours(2))
            };

            foreach (Trip trip in trips)
            {
                car.Drive(trip);
            }

            foreach (Trip trip in car.GetTrips())
            {
                Console.Write(trip.GetTripDetails());
            }

            List <Trip> tripsByDate = car.GetTripsByDate(DateTime.Today);

            DateTime start = DateTime.Today;
            DateTime end = DateTime.Today.AddHours(1).AddMinutes(30);

            List<Trip> tripsInTimeInterval = car.GetTripsInTimeInterval(start, end);
        }
    }
}