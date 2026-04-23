using CarAppGroup8;
using System.Collections.Generic;

public interface ICarRepository
{
    IEnumerable<Car> GetAll();
    Car GetByLicensePlate(string licensePlate);
    void Add(Car car);
    void Update(Car car);
    void Delete(string licensePlate);
}