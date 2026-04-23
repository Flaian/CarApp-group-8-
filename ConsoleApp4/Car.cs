namespace CarAppGroup8
{

    public abstract class Car
    {
        // Properties
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public double Odometer { get; protected set; }


        // Constructor
        public Car(string brand, string model, int year, string licensePlate)
        {
            Brand = brand;
            Model = model;
            Year = year;
            LicensePlate = licensePlate;
        }

        public abstract void UpdateEnergyLevel(double km);

        public override string ToString()
        {
            return "";
        }
    }
}

