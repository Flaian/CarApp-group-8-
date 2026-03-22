namespace CarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string brand = "";
            string model = "";
            int year = 0;
            char gear = '\0';
            string fuelType = "";
            double fuelPrice = 0;
            double kmPrLiter = 0;
            double odometer = 0;
            double distance = 0;
            double tripPrice = 0;
            bool palindrome = false;

            while (true)
            {
                Console.WriteLine("(1) - ReadCarDetails()");
                Console.WriteLine("(2) - Drive()");
                Console.WriteLine("(3) - CalculateTripPrice()");
                Console.WriteLine("(4) - IsPalindrome()");
                Console.WriteLine("(5) - PrintCarDetails()");
                Console.WriteLine("(6) - Exit program");
                Console.WriteLine("\nPlease type the number and then press [Enter]: ");

                char userInput = Console.ReadLine()[0];

                if (userInput == '1')
                {
                    ReadCarDetails(ref brand, ref model, ref year, ref gear, ref fuelType, ref fuelPrice, ref kmPrLiter, ref odometer);
                }

                else if (userInput == '2')
                {
                    Drive(ref distance, ref odometer);
                }

                else if (userInput == '3')
                {
                    tripPrice = CalculateTripPrice(distance, fuelPrice, fuelType, kmPrLiter);
                }

                else if (userInput == '4')
                {
                    IsPalindrome(odometer, ref palindrome);
                }

                else if (userInput == '5')
                {
                    PrintCarDetails(fuelType, kmPrLiter, odometer, distance, tripPrice);
                }

                else if (userInput == '6')
                {
                    Console.WriteLine("Goodbye");
                    break;
                }
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

        static void PrintCarDetails(string fuelType, double kmPrLiter, double odometer, double distance, double tripPrice)
        {
            Console.WriteLine($"Fuel type:              {fuelType}");
            Console.WriteLine($"Km/l:                   {kmPrLiter}");
            Console.WriteLine($"Odometer pre-trip:      {odometer - distance}");
            Console.WriteLine($"Odometer post-trip:     {odometer}");
            Console.WriteLine($"Fuel price for trip:    {tripPrice}");
            Console.WriteLine(string.Format("Fuel expenses for {0} km is {1} DKK", distance, tripPrice));
        }
    }
}