using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace ConsoleApp4
{
    public class Car
    {

       
        
            // general car propotys 
           public string Brand { get; private set; }
           public string Model { get; private set; }     
           public int Year { get; private set; }
        public string LicensePlate { get; private set; }
           public FuelType fuelType { get; private set; }
           public double KmPerLiter { get; private set; }
           public double odometer { get; private set; }

        private List<Trip> _trips = new List<Trip>();
		private Engine _engine;



		public Car(string brand,string model,int  year, string licensePlate,FuelType fuelType, double KmPerLiter, double Odometer) 
        {
			Brand = brand;

			Model = model;

			Year = year;

			LicensePlate = licensePlate;

			FuelType = fuelType;

			KmPerLiter = kmPerLiter;

			_engine = new Engine();
		}


        public void TurnOnEngine() => _engine.Start();
		public void TurnOffEngine() => _engine.Stop();


        public void Drive(Trip newTrip)
        { if (newTrip.Car == this)
            {
                odometer += newTrip.Distance;
                _trips.Add(newTrip);
            }
            else
            {
                Console.WriteLine("Fej: Denne tur tilhører ikke denne bil.");
            }




			}






        


        }            





	}
}
