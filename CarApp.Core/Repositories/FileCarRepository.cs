namespace CarApp.Core.Models
{
    public class FileCarRepository : ICarRepository
    {
        public string FilePath { get; set; }

        public FileCarRepository(string filePath)
        {
            FilePath = filePath;

            if (!File.Exists(FilePath))
                using (File.Create(FilePath)) { }
        }

        public IEnumerable<Car> GetAll()
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
                    else if (line.Split(',')[0] == "ElectricCar")
                    {
                        cars.Add(ElectricCar.FromString(line));
                    }
                }
            }
            return cars;
        }

        public Car GetByLicensePlate(string licensePlate)
        {
            foreach (Car car in GetAll())
            {
                if (car.LicensePlate == licensePlate)
                {
                    return car;
                }
            }
            return null;
        }

        public void Add(Car car)
        {
            using (StreamWriter sw = new StreamWriter(FilePath, append: true))
            {
                sw.WriteLine(car.ToString());
            }
        }

        public void Update(Car car)
        {

            List<Car> cars = new List<Car>(GetAll());

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].LicensePlate == car.LicensePlate)
                {
                    cars[i] = car;
                    break;
                }
            }

            using (StreamWriter sw = new StreamWriter(FilePath, append: false))
            {
                foreach (Car currentCar in cars)
                    sw.WriteLine(currentCar.ToString());
            }
        }

        public void Delete(string licensePlate)
        {

            List<Car> cars = new List<Car>(GetAll());

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].LicensePlate == licensePlate)
                {
                    cars.RemoveAt(i);
                    break;
                }
            }

            using (StreamWriter sw = new StreamWriter(FilePath))
            {
                foreach (Car currentCar in cars)
                    sw.WriteLine(currentCar.ToString());
            }
        }
    }
}
