namespace CarAppGroup8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test of InMemoryCarRepository
            // ICarRepository repo = new InMemoryCarRepository();
            ICarRepository repo = new FileCarRepository("cars.txt");
            repo.Add(new FuelCar("Toyota", "Corolla", 2022, "AB12345", 50, 18, 45000));
            repo.Add(new ElectricCar("Tesla", "Model 3", 2023, "CD67890", 75, 6.5, 380000));

            List<String> tempList = new List<String>();
            // Fetch all cars and print them
            foreach (Car car in repo.GetAll())
            {
                // Here is the fix to avoid double shiet in the file
                if (repo.GetByLicensePlate(car.LicensePlate) != null)
                {
                    if (tempList.Contains(car.LicensePlate))
                    {
                        repo.Delete(car.LicensePlate);
                    }
                    else
                    {
                        tempList.Add(car.LicensePlate);
                    }
                }
            }

            // Fetch a specific car by license plate
            Car found = repo.GetByLicensePlate("AB12345");
            Console.WriteLine(found != null ? $"Found: {found.Brand} {found.Model}" : "Car not found");

            // Delete a car and verify deletion
            // repo.Delete("AB12345");
            Console.WriteLine($"Number of cars: {repo.GetAll().Count()}"); // 1

            repo.Update(new ElectricCar("Tesla", "Model 69", 2025, "CD67890", 80, 22, 15000));



            /*DataHandler dh = new DataHandler("..\\..\\..\\cars.txt");

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
            dh.SaveCarsToFile(cars);*/
        }


        /*// Method to generate random cars and add them to the list
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
                        Console.WriteLine("Duplicate license plate generated: " + licensePlate);
                        break; // Skip duplicate license plate
                    }
                }

                if (isDuplicate == false)
                {
                    return licensePlate;
                }
            }
        }*/
    }
}