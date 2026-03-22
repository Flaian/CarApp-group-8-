public class Car
{
    private string _brand;
    private string _model;
    private int _year;
    private char _gear;
    private double _odometer;
    private string _fuelType;
    private bool _isEngineOn;
    private double _kmPrLiter;

	// Constructor
	public Car(string brand, string model, int year, char gear, double odometer, string fuelType, bool isEngineOn, double kmPrLiter)
	{
		_brand = brand;
		_model = model;
		_year = year;
		_gear = gear;
		_odometer = odometer;
		_fuelType = fuelType;
		_isEngineOn = isEngineOn;
		_kmPrLiter = kmPrLiter;
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

    public string FuelType
    {
        get
        {
            return _fuelType;
        }
    }

    public double KmPrLiter
    {
        get
        {
            return _kmPrLiter;
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

    // Method - Drive()
    public void Drive(double distance)
    {
        if (_isEngineOn)
        {
            _odometer += distance;
        }
    }

    // Method - CalculateTripPrice()
    public double CalculateTripPrice(double distance, double fuelPrice)
    {
        if (_kmPrLiter == 0)
        {
            return 0;
        }

        if (_fuelType != "Gasoline" && _fuelType != "Diesel")
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
}
