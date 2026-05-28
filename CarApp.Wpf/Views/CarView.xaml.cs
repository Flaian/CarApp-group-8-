using CarApp.Wpf.ViewModels;
using System.Windows.Controls;

namespace CarApp.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CarView : UserControl
    {
        public CarView()
        {
            InitializeComponent();
        }

        private void InputTextChanged(object sender, TextChangedEventArgs e)
        {
            if (DataContext is CarViewModel viewModel)
            {
                (viewModel.AddCarCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }
    }
}