using CarApp.Core.Models;
using CarApp.Core.Repositories;

namespace CarApp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test of InMemoryCarRepository
            // ICarRepository repo = new InMemoryCarRepository();


            ICarRepository repo = new FileCarRepository("cars.txt");


            File.WriteAllText("cars.txt", string.Empty);

            // Add cars
            repo.Add(new FuelCar("Toyota", "Corolla", 2022, "AB12345", 50, 18, 45000));
            repo.Add(new ElectricCar("Tesla", "Model 3", 2023, "CD67890", 75, 6.5, 380000));

            Console.WriteLine("=== AFTER ADD ===");
            foreach (Car car in repo.GetAll())
            {
                Console.WriteLine(car);
            }

            // Test GetByLicensePlate
            Console.WriteLine("\n=== GET BY LICENSE PLATE ===");
            Car found = repo.GetByLicensePlate("AB12345");
            Console.WriteLine(found != null ? found.ToString() : "Car not found");

            // Test Update
            Console.WriteLine("\n=== AFTER UPDATE ===");
            repo.Update(new FuelCar("Toyota", "Corolla", 2022, "AB12345", 60, 20, 46000));

            foreach (Car car in repo.GetAll())
            {
                Console.WriteLine(car);
            }

            // Test Delete
            repo.Delete("CD67890");

            Console.WriteLine("\n=== AFTER DELETE ===");
            foreach (Car car in repo.GetAll())
            {
                Console.WriteLine(car);
            }
        }
    }
}