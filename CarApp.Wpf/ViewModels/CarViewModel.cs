using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using CarApp.Core.Models;
using CarApp.Core.Repositories;

namespace CarApp.Wpf.ViewModels
{
    public class CarViewModel : INotifyPropertyChanged
    {
        private readonly ICarRepository _repository;

        public ObservableCollection<Car> Cars { get; set; }

        private Car _selectedCar;
        public Car SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                OnPropertyChanged(nameof(SelectedCar));
                (UpdateCarCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (DeleteCarCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        private string _searchPlate;
        public string SearchPlate
        {
            get => _searchPlate;
            set { _searchPlate = value; OnPropertyChanged(nameof(SearchPlate)); }
        }

        public ICommand AddCarCommand { get; }
        public ICommand FindCarCommand { get; }
        public ICommand UpdateCarCommand { get; }
        public ICommand DeleteCarCommand { get; }

        public CarViewModel(ICarRepository repository)
        {
            _repository = repository;
            Cars = new ObservableCollection<Car>(_repository.GetAll());
            SelectedCar = new FuelCar("", "", DateTime.Now.Year, "", 40, 10, 0);

            AddCarCommand = new RelayCommand(_ => AddCar(), _ => CanAddCar());
            FindCarCommand = new RelayCommand(_ => FindCar(), _ => !string.IsNullOrWhiteSpace(SearchPlate));
            UpdateCarCommand = new RelayCommand(_ => UpdateCar(), _ => CanUpdateOrDelete());
            DeleteCarCommand = new RelayCommand(_ => DeleteCar(), _ => CanUpdateOrDelete());
        }

        private bool CanAddCar()
        {
            return SelectedCar != null &&
                !string.IsNullOrWhiteSpace(SelectedCar.LicensePlate) &&
                !string.IsNullOrWhiteSpace(SelectedCar.Brand) &&
                !string.IsNullOrWhiteSpace(SelectedCar.Model);
        }

        private void AddCar()
        {
            // TODO: Add SelectedCar to _repository and to the Cars-list
            // TODO: Clear SelectedCar to a new empty FuelCar
        }

        private void FindCar()
        {
            // TODO: Use _repository.GetByLicensePlate(SearchPlate)
            // TODO: If found, set SelectedCar = found car, clear SearchPlate
            // TODO: If not found, show MessageBox.Show("Car not found")
        }

        private bool CanUpdateOrDelete()
        {
            // TODO: Return true if SelectedCar does not have an empty LicensePlate
            return false; // temporary
        }

        private void UpdateCar() { /* This method is given in exercise 6 */}

        private void DeleteCar()
        { /* This method is given in exercise 6 */ }

        private void RefreshCarList()
        {
            Cars.Clear();
            foreach (var car in _repository.GetAll()) Cars.Add(car);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
