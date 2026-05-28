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
            set
            {
                _searchPlate = value; OnPropertyChanged(nameof(SearchPlate));
            }
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
            return SelectedCar != null
                && !string.IsNullOrWhiteSpace(SelectedCar.Brand)
                && !string.IsNullOrWhiteSpace(SelectedCar.Model)
                && SelectedCar.Year >= 1884
                && SelectedCar.Year <= DateTime.Now.Year
                && !string.IsNullOrWhiteSpace(SelectedCar.LicensePlate);
        }

        private void AddCar()
        {
            _repository.Add(SelectedCar);
            Cars.Add(SelectedCar);

            SelectedCar = new FuelCar("", "", DateTime.Now.Year, "", 40, 10, 0);
        }

        private void FindCar()
        {
            Car foundCar = _repository.GetByLicensePlate(SearchPlate);

            if (foundCar != null)
            {
                SelectedCar = foundCar;
                SearchPlate = string.Empty;
            }
            else
            {
                MessageBox.Show("Car not found");
            }
        }

        private bool CanUpdateOrDelete()
        {
            return SelectedCar != null && !string.IsNullOrWhiteSpace(SelectedCar.LicensePlate);
        }

        private void UpdateCar()
        {
            _repository.Update(SelectedCar);
            RefreshCarList();
        }

        private void DeleteCar()
        {
            var result = MessageBox.Show(
                $"Do you want to delete {SelectedCar.Brand} {SelectedCar.Model}?",
                "Confirm deletion",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                _repository.Delete(SelectedCar.LicensePlate);
                Cars.Remove(SelectedCar);
                SelectedCar = new FuelCar("", "", DateTime.Now.Year, "", 40, 10, 0);
            }
        }

        private void RefreshCarList()
        {
            Cars.Clear();
            foreach (var car in _repository.GetAll()) Cars.Add(car);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}