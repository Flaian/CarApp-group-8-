namespace CarAppGroup8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*FuelCar fuelCar = new FuelCar("Toyota", "Corolla", 2022, "AB12345", 50, 18);
            ElectricCar electricCar = new ElectricCar("Tesla", "Model 3", 2023, "CD67890", 75, 6.5);
            FuelCar fuelCarBimmer = new FuelCar("BMW", "320d", 2021, "XY99999", 60, 15);

            List<Car> cars = new List<Car>();
            cars.Add(fuelCar);
            cars.Add(electricCar);
            cars.Add(fuelCarBimmer);

            DataHandler dh = new DataHandler("..\\..\\..\\cars.txt");
            dh.SaveCarsToFile(cars);
            dh.LoadCarsFromFile();*/


            DataHandler dh = new DataHandler("..\\..\\..\\cars.txt");

            // Load cars from file
            List<Car> cars = dh.LoadCarsFromFile();

            // Add random cars
            cars.Add(CreateRandomCar(cars));

            // Print list
            Console.WriteLine("Current cars:\n");
            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }

            // Save updated list to file
            dh.SaveCarsToFile(cars);
        }


        // Method to generate random cars and add them to the list
        static Car CreateRandomCar(List<Car> cars)
        {
            Random rnd = new Random();

            if (rnd.Next(2) == 0)
            {
                FuelCar fuelCar = new FuelCar(
                    GetRandomFuelBrand(rnd), GetRandomFuelModel(rnd), rnd.Next(2000, 2025),
                    GetRandomPlate(rnd, cars), rnd.Next(40, 80), rnd.Next(10, 25));
                return fuelCar;
            }

            else
            {
                ElectricCar electricCar = new ElectricCar(
                    GetRandomElectricBrand(rnd), GetRandomElectricModel(rnd), rnd.Next(2018, 2025),
                    GetRandomPlate(rnd, cars), rnd.Next(50, 100), rnd.Next(4, 8));
                return electricCar;
            }
        }

        // Helper methods to generate random data
        static string GetRandomFuelBrand(Random rnd)
        {
            string[] brands = { "Toyota", "BMW", "Audi", "Ford", "Volkswagen" };
            return brands[rnd.Next(brands.Length)];
        }

        static string GetRandomFuelModel(Random rnd)
        {
            string[] models = { "Corolla", "320d", "A4", "Focus", "Golf" };
            return models[rnd.Next(models.Length)];
        }


        static string GetRandomElectricBrand(Random rnd)
        {
            string[] brands = { "Tesla", "Polestar", "Nissan", "Hyundai", "Kia" };
            return brands[rnd.Next(brands.Length)];
        }

        static string GetRandomElectricModel(Random rnd)
        {
            string[] models = { "Model 3", "Model Y", "Leaf", "Ioniq 5", "EV6" };
            return models[rnd.Next(models.Length)];
        }


        static string GetRandomPlate(Random rnd, List<Car> cars)
        {
            while (true)
            {
                string licensePlate = $"{(char)rnd.Next('A', 'Z')}{(char)rnd.Next('A', 'Z')}{rnd.Next(10000, 99999)}";

                bool isDuplicate = false;
                foreach (Car car in cars)
                {
                    if (car.LicensePlate == licensePlate)
                    {
                        isDuplicate = true;
                        break; // Skip duplicate license plate
                    }
                }

                if (isDuplicate == false)
                {
                    return licensePlate;
                }
            }
        }
    }
}