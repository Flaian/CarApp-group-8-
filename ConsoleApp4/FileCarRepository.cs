using System;
using System.Collections.Generic;
using System.Text;

namespace CarAppGroup8
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

            foreach (Car carCar in GetAll())
            {
                if (carCar.LicensePlate == car.LicensePlate)
                {
                    cars[cars.FindIndex(carCarCar => carCarCar.LicensePlate == car.LicensePlate)] = car;
                }
            }

            using (StreamWriter sw = new StreamWriter(FilePath, append: false))
            {
                foreach (Car carCarCarCar in cars) // For traceability
                    sw.WriteLine(carCarCarCar.ToString());
            }
        }

        public void Delete(string licensePlate)
        {
            List<Car> cars = new List<Car>(GetAll());

            Car car = GetByLicensePlate(licensePlate);

            if (car != null)
            {
                cars.Remove(cars[cars.FindIndex(carCar => carCar.LicensePlate == licensePlate)]);
            }

            using (StreamWriter sw = new StreamWriter(FilePath))
            {
                foreach (Car carCarCarCarCar in cars) // FOR THE LOOOOOOORE
                    sw.WriteLine(carCarCarCarCar.ToString());
            }
        }
    }
}
