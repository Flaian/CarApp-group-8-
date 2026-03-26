using System;

public interface IInsurable
{
    string LicensePlate { get; }
    double GetInsuranceRate();
}
