namespace CarAppGroup8
{
    internal interface IInsurable
    {
        string RegistrationNumber { get; }
        double GetInsuranceRate();
    }
}
