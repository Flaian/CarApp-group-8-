using Microsoft.VisualBasic;
using System;

public class Trip
{
    private Car _car;
    private double _distance;
	private DateTime _startTime;
	private DateTime _endTime;
    private DateTime _tripDate;

    public Trip(Car car, double distance, DateTime startTime, DateTime endTime)
    {
        _car = car;
        _distance = distance;
		_startTime = startTime;
		_endTime = endTime;
        _tripDate = startTime.Date;
    }

	// Read-only property
	public Car Car
	{
		get
		{
            return _car;
		}
	}

    // Read+Write properties
    public double Distance
    {
        get
        {
            return _distance;
        }
        private set
        {
            _distance = value;
        }
    }

    public DateTime StartTime
    {
        get
        {
            return _startTime;
        }
        private set
        {
            _startTime = value;
        }
    }

    public DateTime EndTime
    {
        get
        {
            return _endTime;
        }
        private set
        {
            _endTime = value;
        }
    }

    public DateTime TripDate
    {
        get
        {
            return _tripDate;
        }
        private set
        {
            _tripDate = value;
        }
    }
}
