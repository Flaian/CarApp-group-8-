// CarApp.Core/Models/Trip.cs
namespace CarApp.Core.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Distance { get; set; }

        public Trip(Car car, DateTime startTime, DateTime endTime, double distance)
        {
            Car = car;
            StartTime = startTime;
            EndTime = endTime;
            Distance = distance;
        }

        // Beregn varighed i minutter
        public double DurationMinutes =>
            (EndTime - StartTime).TotalMinutes;
    }
}
