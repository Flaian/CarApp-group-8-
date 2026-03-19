namespace ConsoleApp4
{
	using System;

	using System.Collections.Generic;

	internal class Program
    {




        static void Main(string[] args)
        {

			// Opret bil
			Car myCar = new Car("Toyota", "Corolla", 2020, "AB12345", FuelType.Benzin, 22.5);

			myCar.TurnOnEngine();

			// Opret ture – alle er fuldt initialiseret via konstruktøren

			List<Trip> trips = new List<Trip>
			{
				new Trip( myCar, 50, DateTime.Now, DateTime.Now.AddHours(1)),
				new Trip(myCar, 30, DateTime.Now, DateTime.Now.AddMinutes(30)),
				new Trip(myCar, 100, DateTime.Now, DateTime.Now.AddHours(2))

			};

			// Drive tilføjer én tur ad gangen og tjekker bil-tilhørsforhold
			foreach (var trip in trips)
			{ 
			
              myCar.Drive(trip);
				// Main har ansvar for udskrivningen – ikke Car
				Console.WriteLine("\n--- Alle Ture ---");
				foreach (var trip in myCar.GetTrips())
				{
					Console.WriteLine(trip.GetTripDetails());
                }

				Console.WriteLine(($"\nOdometer: {myCar.Odometer} km");
			}
		}
	}
}
