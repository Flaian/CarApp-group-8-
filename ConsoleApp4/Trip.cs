namespace CarAppGroup8
{
    public class Trip
    {

        // Private felt – Car-referencen må ikke ændres udefra

        private readonly Car _car;


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


        // Returnerer turens data som formateret tekst
        public string GetTripDetails()
        {
            return $"Dato: {TripDate:dd-MM-yyyy} | " +
                   $"Distance: {Distance} km | " +
                   $"Start: {StartTime:HH:mm} | " +
                   $"Slut: {EndTime:HH:mm} | " +
                   $"Varighed: {CalculateDuration()}";
        }
    }
}
