using CarApp.Core.Models;

namespace CarApp.Core.Repositories
{
    public class InMemoryTripRepository : ITripRepository
    {

        private readonly List<Trip> _trips = new List<Trip>();
        public void Add(Trip trip)
        {
            _trips.Add(trip);
        }

        public void Delete(int id)
        {
            Trip trip = GetById(id);
            if (trip != null)
            {
                _trips.Remove(trip);
            }
        }

        public IEnumerable<Trip> GetAll()
        {
            return _trips;
        }

        public Trip GetById(int id)
        {
            int i = _trips.FindIndex(t => t.Id == id);
            if (i >= 0)
            {
                return _trips[i];
            }
            return null;
        }

        public IEnumerable<Trip> GetTripsByCarLicensePlate(string licensePlate)
        {
            List<Trip> matchingTrips = new List<Trip>();

            foreach (Trip trip in _trips)
            {
                if (trip.Car != null && trip.Car.LicensePlate == licensePlate)
                {
                    matchingTrips.Add(trip);
                }
            }

            return matchingTrips;
        }
    }
}
