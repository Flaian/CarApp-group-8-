using CarApp.Wpf.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CarApp.Wpf.Views
{
    /// <summary>
    /// Interaction logic for CarView.xaml
    /// </summary>
    public partial class CarView : Window
    {
        public CarView()
        {
            InitializeComponent();
        }

        private void InputFieldChanged(object sender, TextChangedEventArgs e)
        {
            if (DataContext is CarViewModel vm)
            {
                (vm.AddCarCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        private void CarSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is CarViewModel vm)
            {
                (vm.UpdateCarCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (vm.DeleteCarCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }
    }
}
