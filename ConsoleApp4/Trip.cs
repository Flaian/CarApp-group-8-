using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp4
{
    public class Trip
    {
		// Private felt – Car-referencen må ikke ændres udefra

		public double Distance { get; private set; }
		public DateTime TripDate { get; private set; }
		public DateTime StartTime { get; private set; }
		public DateTime EndTime { get; private set; }

		// Public property så Drive() i Car kan sammenligne med 'this'
		public Car Car => _car;

		public Trip(Car car, double distance, DateTime startTime, DateTime endTime)
		{

			_car = car;
			Distance = distance;
			StartTime = startTime;
			EndTime = endTime;
			TripDate = startTime.Date; // Udledes automatisk

		}
		// Returnerer turens varighed
		public TimeSpan CalculateDuration()
		{
			return EndTime - StartTime;
        }
		// Beregner brændstofforbrug i liter
		public double CalculateFuelUsed()
		{
			return Distance / _car.KmPerLiter;
		}
		// Beregner turens pris i kr.

		public double CalculateTripPrice(double literPrice)
		{
			return CalculateFuelUsed * literPrice;
		}
		// Returnerer turens data som formateret tekst
		public string GetTripDetails()
		{
			return $"Dato: {TripDate:dd-MM-yyyy} | " +

                   $"Distance: {Distance} km | " +
                   
                   $"Varighed: {CalculateDuration()} | " +
                   
                   $"Brændstof: {CalculateFuelUsed():F2} L | " +
                   
                   $"Pris (14 kr/L): {CalculateTripPrice(14):F2} kr";

		}

	}
}
