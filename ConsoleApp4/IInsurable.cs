using System;

public interface IInsurable
{
    string RegistrationNumber { get; }
    double GetInsuranceRate();
}
