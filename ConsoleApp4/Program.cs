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

            FuelCar fuelCar = new FuelCar("Mazda", "3", 2019, "DW60547", 50.0, 19.0);
            ElectricCar electricCar = new ElectricCar("Tesla", "Model 3", 2022, "EL99999", 75.0, 6.5);

            List<Car> cars = new List<Car>();
            cars.Add(fuelCar);
            cars.Add(electricCar);

            DataHandler dh = new DataHandler("..\\..\\..\\cars.txt");
            dh.SaveCarsToFile(cars);
            dh.LoadCarsFromFile();
        }
    }
}