namespace CarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Hyundai", "i10", 2012, 'M', 130031, "Gasoline", false, 18.9);
            Car car2 = new Car("Rover", "25", 2010, 'A', 72700, "Diesel", false, 17.6);

            double fuelPrice = 14.33;
            double distance = 50;
            double tripPrice = 0;
            bool palindrome = false;

            while (true)
            {
                Console.WriteLine("(1) - Toggle the engine");
                Console.WriteLine("(2) - Go for a trip");
                Console.WriteLine("(3) - Calculate fuel expenses");
                Console.WriteLine("(4) - Change details of your car");
                Console.WriteLine("(5) - Show the details of the car");
                Console.WriteLine("(6) - Exit program");
                Console.WriteLine("\nPlease type the number and then press [Enter]: ");

                char userInput = Console.ReadLine()[0];

                if (userInput == '1')
                {
                    car1.ToggleEngine();
                    Console.WriteLine(car1.IsEngineOn ? "The engine has been turned on" : "The engine has been turned off");
                }

                else if (userInput == '2')
                {
                    car1.Drive(distance);
                }

                else if (userInput == '3')
                {
                    tripPrice = car1.CalculateTripPrice(distance, fuelPrice);

                }

                else if (userInput == '4')
                {
                    while (true)
                    {
                        Console.Write("Write down the new number for the odometer: ");

                        if (double.TryParse(Console.ReadLine(), out double odometerInput))
                        {
                            if (odometerInput >= 0)
                            {
                                car1.Odometer = odometerInput;
                                break;
                            }

                            else if (odometerInput < car1.Odometer)
                            {
                                Console.WriteLine("Your input is lower than the car's registered odometer value and will therefore not change");
                            }

                            else
                            {
                                Console.WriteLine("Your input cannot be a negative number");
                            }
                        }

                        else
                        {
                            Console.WriteLine("That is not a useful number, please try again");
                        }
                    }
                }

                else if (userInput == '5')
                {
                    Console.WriteLine(car1.GetCarDetails());
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