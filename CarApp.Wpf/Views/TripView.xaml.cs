using CarApp.Wpf.ViewModels;
using System.Windows.Controls;

namespace CarApp.Wpf.Views
{
    /// <summary>
    /// Interaction logic for TripView.xaml
    /// </summary>
    public partial class TripView : UserControl
    {
        public TripView()
        {
            InitializeComponent();
        }

        private void InputTextChanged(object sender, TextChangedEventArgs e)
        {
            if (DataContext is TripViewModel viewModel)
            {
                (viewModel.AddTripCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }
    }
}


