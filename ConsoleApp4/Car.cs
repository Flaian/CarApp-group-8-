namespace CarAppGroup8
{

    public abstract class Car
    {
        // Properties
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public string LicensePlate { get; private set; }
        public double Odometer { get; protected set; }
        public bool IsEngineOn { get; private set; }

        private List<Trip> _trips = new List<Trip>();


        // Constructor
        public Car(string brand, string model, int year, string licensePlate)
        {
            Brand = brand;
            Model = model;
            Year = year;
            LicensePlate = licensePlate;
        }


        public abstract void UpdateEnergyLevel(double km);

        public void Drive(Trip trip)
        {
            if (IsEngineOn)
            {
                Odometer += trip.Distance;
                _trips.Add(trip);

                UpdateEnergyLevel(trip.Distance);
            }
            else
            {
                Console.WriteLine("Error, engine is not on.");
            }
        }

        public void ToggleEngine()
        {
            IsEngineOn = !IsEngineOn;
        }

        public List<Trip> GetTrips()
        {
            return _trips;
        }

        public List<Trip> GetTripsByDate(DateTime date)
        {
            List<Trip> result = new List<Trip>();
            foreach (Trip trip in _trips)
                if (trip.TripDate.Date == date.Date)
                    result.Add(trip);
            return result;
        }

        public List<Trip> GetTripsInTimeInterval(DateTime start, DateTime end)
        {
            List<Trip> result = new List<Trip>();
            foreach (Trip trip in _trips)
                if (trip.StartTime >= start && trip.StartTime <= end)
                    result.Add(trip);
            return result;
        }
    }
}

