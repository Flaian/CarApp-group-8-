using CarApp.Core.Models;


namespace CarAppGroup8
{
    public class DataHandler
    {
        public string FilePath { get; private set; }

        // Constructor
        public DataHandler(string filePath)
        {
            FilePath = filePath;
        }

        // Methods
        public void SaveCarsToFile(List<Car> cars)
        {
            using (StreamWriter sw = new StreamWriter(FilePath))
            {
                List<Car> uniqueCars = new List<Car>();

                foreach (Car car in cars)
                {
                    bool exists = false;

                    foreach (Car c in uniqueCars)
                    {
                        if (c.LicensePlate == car.LicensePlate)
                        {
                            exists = true;
                            break;
                        }
                    }

                    if (!exists)
                    {
                        uniqueCars.Add(car);
                        sw.WriteLine(car.ToString());
                    }
                }
            }
        }

        public List<Car> LoadCarsFromFile()
        {
            List<Car> cars = new List<Car>();

            if (!File.Exists(FilePath))
            {
                return cars; // Return empty list if file doesn't exist
            }

            using (StreamReader sr = new StreamReader(FilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Split(',')[0] == "FuelCar")
                    {
                        cars.Add(FuelCar.FromString(line));
                    }
                    else
                    {
                        cars.Add(ElectricCar.FromString(line));
                    }
                }
                return cars;
            }
        }
    }
}