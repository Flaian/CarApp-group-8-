public class Car
{
    private readonly string _brand;
    private readonly string _model;
    private readonly int _year;
    private readonly char _gear;
    private double _odometer;
    private FuelType _fuelType;
    private bool _isEngineOn;
    private readonly double _kmPrLiter;
    private readonly string _licensePlate;
    private List<Trip> _trips = [];

	// Constructor
	public Car(string brand, string model, int year, char gear, double odometer, FuelType fuelType, bool isEngineOn, double kmPrLiter, string licensePlate)
	{
		_brand = brand;
		_model = model;
		_year = year;
		_gear = gear;
		_odometer = odometer;
		_fuelType = fuelType;
		_isEngineOn = isEngineOn;
		_kmPrLiter = kmPrLiter;
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

    public char Gear
    {
        get
        {
            return _gear;
        }
    }

    public double KmPrLiter
    {
        get
        {
            return _kmPrLiter;
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
    public FuelType FuelType
    {
        get
        {
            return _fuelType;
        }

        private set
        {
            _fuelType = value;
        }
    }

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

    // Method - Drive()
    public void Drive(Trip newTrip)
    {
        if (_isEngineOn)
        {
            _odometer += newTrip.Distance;
            _trips.Add(newTrip);
        }
    }

    // Method - CalculateTripPrice()
    public double CalculateTripPrice(double distance, double fuelPrice)
    {
        if (_kmPrLiter == 0)
        {
            return 0;
        }

        if (_fuelType != FuelType.Gasoline && _fuelType != FuelType.Diesel)
        {
            return 0;
        }

        return Math.Round((distance / _kmPrLiter) * fuelPrice, 2);
    }

    // Method - GetCarDetails()
    public string GetCarDetails()
    {
        return $"Brand: {Brand}\nModel: {Model}\nYear: {Year}\nGear: {Gear}\nOdometer: {Odometer}\n" +
            $"Fuel type: {FuelType}\nState of engine: {(IsEngineOn ? "On" : "Off")}\nKm/L: {KmPrLiter}";
    }

    // Method - GetTrips()
    public List<Trip> GetTrips()
    {
        return _trips;
    }
}
