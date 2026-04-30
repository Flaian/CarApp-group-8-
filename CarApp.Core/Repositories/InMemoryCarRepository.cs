using CarApp.Core.Models;

namespace CarApp.Core.Reposisitories;

public class InMemoryCarRepository : ICarRepository
{
    private readonly List<Car> _cars = new List<Car>();

    public IEnumerable<Car> GetAll()
    {
        return _cars;
    }

    public Car GetByLicensePlate(string licensePlate)
    {
        int i = _cars.FindIndex(c => c.LicensePlate == licensePlate);
        if (i != -1) return _cars[i];
        return null;
    }

    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void Update(Car car)
    {
        int i = _cars.FindIndex(c => c.LicensePlate == car.LicensePlate);
        if (i != -1) _cars[i] = car;
    }

    public void Delete(string licensePlate)
    {
        Car car = GetByLicensePlate(licensePlate);
        if (car != null)
        {
            _cars.Remove(car);
        }
    }
}