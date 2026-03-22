namespace CarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double fuelPrice = 14.33;
            double tripPrice = 0;
            bool palindrome = false;

            Car car = new Car("Hyundai", "i10", 2012, 'M', 130031, FuelType.Gasoline, false, 18.9, "CS36036");
            car.ToggleEngine();

            List<Trip> trips = new List<Trip>()
            {
                new Trip(car, 50, DateTime.Now, DateTime.Now.AddHours(1)),
                new Trip(car, 30, DateTime.Now, DateTime.Now.AddMinutes(30)),
                new Trip(car, 100, DateTime.Now, DateTime.Now.AddHours(2))
            };

            foreach (Trip trip in trips)
            {
                car.Drive(trip);
            }
        }

        static void ReadCarDetails(ref string brand, ref string model, ref int year, ref char gear, ref string fuelType, ref double fuelPrice, ref double kmPrLiter, ref double odometer)
        {
            brand = "Hyundai";
            model = "i10";
            year = 2012;
            gear = 'M';
            fuelType = "Gasoline";
            fuelPrice = 13.49;
            kmPrLiter = 18.9;
            odometer = 130031;
        }

        static void IsPalindrome(double odometer, ref bool palindrome)
        {
            string palindromeString = odometer.ToString();
            char[] palindromeReverse = palindromeString.ToCharArray();
            Array.Reverse(palindromeReverse);
            string palindromeReversed = new string(palindromeReverse);

            if (palindromeString == palindromeReversed)
            {
                Console.WriteLine("Your odometer is a palindrome");
            }

            else
            {
                Console.WriteLine("Your odometer is not a palindrome");
            }
        }
    }
}