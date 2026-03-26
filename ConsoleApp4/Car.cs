public abstract class Car
{
    private readonly string _brand;
    private readonly string _model;
    private readonly int _year;
    private double _odometer;
    private bool _isEngineOn;
    private readonly string _licensePlate;
    private List<Trip> _trips = [];

	// Constructor
	public Car(string brand, string model, int year, string licensePlate)
	{
		_brand = brand;
		_model = model;
		_year = year;
        _licensePlate = licensePlate;
	}

    // READ-ONLY properties
    public string Brand
    {
        get
        {
            return _brand;
        }
    }

    public string Model
    {
        get
        {
            return _model;
        }
    }

    public int Year
    {
        get
        {
            return _year;
        }
    }

    public string LicensePlate
    {
        get
        {
            return _licensePlate;
        }
    }

    // Read+Write property
    public bool IsEngineOn
    {
        get
        {
            return _isEngineOn;
        }
        set
        {
            _isEngineOn = value;
        }
    }

    // Read+Write property with validation
    public double Odometer
    {
        get
        {
            return _odometer;
        }
        set
        {
            if (value >= 0)
            {
                _odometer = value;
            }
        }
    }

    // Method - ToggleEngine()
    public void ToggleEngine()
    {
        _isEngineOn = !_isEngineOn;
    }

    // Abstract method - UpdateEnergyLevel(), subclass defines how energy updates
    public abstract void UpdateEnergyLevel(double km);

    // Method - Drive()
    public void Drive(Trip newTrip)
    {
        if (IsEngineOn)
        {
            if (newTrip.Car == this)
            {
                Odometer += newTrip.Distance;
                UpdateEnergyLevel(newTrip.Distance); // This is delegated to the subclass
                _trips.Add(newTrip);
            }
        }
        else
        {
            Console.WriteLine("Despite your efforts, nothing happens... You notice that the engine is off");
        }
    }

    // Method - GetCarDetails()
    public string GetCarDetails()
    {
        return $"Brand: {Brand}\nModel: {Model}\nYear: {Year}\nOdometer: {Odometer}\n" +
            $"State of engine: {(IsEngineOn ? "On" : "Off")}";
    }

    // Method - GetTrips()
    public List<Trip> GetTrips()
    {
        return _trips;
    }

    // Method - GetTripsByDate()
    public List <Trip> GetTripsByDate(DateTime date)
    {
        List<Trip> trips = [];

        foreach (Trip trip in _trips)
        {
            if (date.Date == trip.TripDate.Date)
            {
                trips.Add(trip);
            }
        }

        return trips;
    }

    // Method - GetTripsInTimeInterval
    public List <Trip> GetTripsInTimeInterval(DateTime start, DateTime end)
    {
        List<Trip> trips = [];

        foreach (Trip trip in _trips)
        {
            if (trip.StartTime >= start && trip.StartTime <= end)
            {
                trips.Add(trip);
            }
        }

        return trips;
    }
}
