using System.Windows;
using CarApp.Core.Repositories;
using CarApp.Wpf.ViewModels;

namespace CarApp.Wpf.Views
{
    public partial class  CarView : Window
    {
        public CarView()
        {
            InitializeComponent();

            ICarRepository repository = new FileCarRepository("cars.txt");

            DataContext = new CarViewModel(repository);
        }
    }
}