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
                foreach (Car car in cars)
                {
                    sw.WriteLine(car.ToString());
                }
            }
        }

        public List<Car> LoadCarsFromFile()
        {
            List<Car> cars = new List<Car>();
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