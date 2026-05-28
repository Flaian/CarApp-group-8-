using CarApp.Core.Models;
using CarApp.Core.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace CarApp.Wpf.ViewModels
{
    public class TripViewModel : INotifyPropertyChanged
    {
        private readonly ITripRepository _tripRepository;
        private readonly ICarRepository _carRepository;

        // Listen af ture der vises i UI
        public ObservableCollection<Trip> Trips { get; set; }

        // Biler brugeren kan vælge til en ny tur
        public ObservableCollection<Car> AvailableCars { get; set; }

        // Den bil brugeren har valgt i dropdownlisten
        private Car _selectedCar;
        public Car SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value; OnPropertyChanged(nameof(SelectedCar));
                (AddTripCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        // Den tur brugeren har valgt i listen
        private Trip _selectedTrip;
        public Trip SelectedTrip
        {
            get => _selectedTrip;
            set
            {
                _selectedTrip = value; OnPropertyChanged(nameof(SelectedTrip));
                (DeleteTripCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        private double _distance;
        public double Distance
        {
            get => _distance;
            set
            {
                _distance = value;
                OnPropertyChanged(nameof(Distance));
                (AddTripCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }


        public ICommand AddTripCommand { get; }
        public ICommand DeleteTripCommand { get; }

        public TripViewModel(ITripRepository tripRepository, ICarRepository carRepository)
        {
            _tripRepository = tripRepository;
            _carRepository = carRepository;

            Trips = new ObservableCollection<Trip>(_tripRepository.GetAll());
            AvailableCars = new ObservableCollection<Car>(_carRepository.GetAll());

            AddTripCommand = new RelayCommand(_ => AddTrip(), _ => CanAddTrip());
            DeleteTripCommand = new RelayCommand(_ => DeleteTrip(), _ => SelectedTrip != null);
        }

        private bool CanAddTrip()
        {
            return SelectedCar != null && Distance > 0;
        }

        private void AddTrip()
        {
            Trip trip = new Trip
            (
                SelectedCar,
                DateTime.Now,
                DateTime.Now.AddMinutes(Distance / 1),
                Distance
            );

            _tripRepository.Add(trip);
            Trips.Add(trip);

            Distance = 0;
        }

        public void RefreshCars()
        {
            AvailableCars.Clear();

            foreach (Car car in _carRepository.GetAll())
            {
                AvailableCars.Add(car);
            }
        }

        private void DeleteTrip()
        {
            _tripRepository.Delete(SelectedTrip.Id);
            Trips.Remove(SelectedTrip);
            SelectedTrip = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
