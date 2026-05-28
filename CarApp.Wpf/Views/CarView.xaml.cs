using System.Windows;
using CarApp.Core.Repositories;
using CarApp.Wpf.ViewModels;

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

            DataContext = new CarViewModel(new InMemoryCarRepository());
        }
    }
}