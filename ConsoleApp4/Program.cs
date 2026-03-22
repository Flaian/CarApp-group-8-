namespace CarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Hyundai", "i10", 2012, 'M', 130031, "Gasoline", false, 18.9);
            Car car2 = new Car("Rover", "25", 2010, 'A', 72700, "Diesel", false, 17.6);

            double fuelPrice = 0;
            double distance = 50;
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
                    // ReadCarDetails(ref brand, ref model, ref year, ref gear, ref fuelType, ref fuelPrice, ref kmPrLiter, ref odometer);
                    Console.WriteLine("Coming soon...");
                }

                else if (userInput == '2')
                {
                    car1.Drive(distance);
                }

                else if (userInput == '3')
                {
                    // tripPrice = CalculateTripPrice(distance, fuelPrice, fuelType, kmPrLiter);
                }

                else if (userInput == '4')
                {
                    // IsPalindrome(odometer, ref palindrome);
                }

                else if (userInput == '5')
                {
                    // PrintCarDetails(fuelType, kmPrLiter, odometer, distance, tripPrice);
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
    }
}