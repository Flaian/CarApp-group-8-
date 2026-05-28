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
            // TODO: Return true if SelectedCar is not null and LicensePlate, Brand and Model are not empty
            return false;
        }

        private void AddCar()
        {
            // TODO: Add SelectedCar to _repository and to the Cars-list
            // TODO: Reset SelectedCar to a new empty FuelCar
        }

        private void FindCar()
        {
            // TODO: Use _repository.GetByLicensePlate(SearchPlate)
            // TODO: If found: Set SelectedCar = found car, clear SearchPlate
            // TODO: If not found, show MessageBox.Show("Car not found")
        }

        private bool CanUpdateOrDelete()
        {
            // TODO: Return true if SelectedCar's LicensePlate is not empty
            return false;
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