using CarApp.Core.Models;
using CarApp.Core.Repositories;
using CarApp.Wpf.ViewModels;

[TestClass]
public class CarViewModelTests
{
    // Helper: opret en frisk ViewModel med InMemoryCarRepository
    private CarViewModel CreateViewModel()
    {
        var repo = new InMemoryCarRepository();
        return new CarViewModel(repo);
    }

    // ── TEST 1: UDLEVERET — kør den og forstå strukturen ────
    [TestMethod]
    public void AddCar_ThenGetAll_ReturnsAddedCar()
    {
        // Arrange
        var vm = CreateViewModel();
        vm.SelectedCar = new FuelCar("Toyota", "Corolla", 2022, "AB12345", 50, 18, 45000);

        // Act
        vm.AddCarCommand.Execute(null);

        // Assert
        Assert.AreEqual(1, vm.Cars.Count);
        Assert.AreEqual("AB12345", vm.Cars[0].LicensePlate);
    }

    // ── TEST 2: UDFYLD Assert-delen ──────────────────────────
    [TestMethod]
    public void GetByLicensePlate_WhenCarExists_ReturnsCorrectCar()
    {
        // Arrange
        var vm = CreateViewModel();
        vm.SelectedCar = new FuelCar("BMW", "320d", 2021, "XY99999", 60, 15, 320000);
        vm.AddCarCommand.Execute(null);
        vm.SearchPlate = "XY99999";

        // Act
        vm.FindCarCommand.Execute(null);

        // Assert 
        Assert.AreEqual("XY99999", vm.SelectedCar.LicensePlate);
        Assert.AreEqual(string.Empty, vm.SearchPlate);
    }

    // ── TEST 3: UDFYLD Act-delen ─────────────────────────────
    [TestMethod]
    public void DeleteCar_RemovesCarFromRepository()
    {
        // Arrange
        var vm = CreateViewModel();
        vm.SelectedCar = new FuelCar("Toyota", "Rav4", 2020, "AB67345", 50, 18, 85000);
        vm.AddCarCommand.Execute(null);

        // Act   
        vm.SelectedCar = vm.Cars[0];
        vm.DeleteCarCommand.Execute(null);

        // Assert
        Assert.AreEqual(0, vm.Cars.Count);
    }
}
