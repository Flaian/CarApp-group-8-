namespace CarAppGroup8
{
    internal class Program
    {
        static void Main(string[] args)
        {


            /*FuelCar fuelCar = new FuelCar("Mazda", "3", 2019, "DW60547", 50.0, 19.0);
            ElectricCar electricCar = new ElectricCar("Tesla", "Model 3", 2022, "EL99999", 75.0, 6.5);

            Console.WriteLine(fuelCar.ToString());
            Console.WriteLine(electricCar.ToString());


            Console.ReadKey();*/

            FuelCar fuelCar = new FuelCar("Toyota", "Corolla", 2022, "AB12345", 50, 18);
            ElectricCar electricCar = new ElectricCar("Tesla", "Model 3", 2023, "CD67890", 75, 6.5);
            FuelCar fuelCarBimmer = new FuelCar("BMW", "320d", 2021, "XY99999", 60, 15);

            List<Car> cars = new List<Car>();
            cars.Add(fuelCar);
            cars.Add(electricCar);
            cars.Add(fuelCarBimmer);

            DataHandler dh = new DataHandler("..\\..\\..\\cars.txt");
            dh.SaveCarsToFile(cars);
            dh.LoadCarsFromFile();
        }
    }
}