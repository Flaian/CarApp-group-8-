using System;

public interface ISellable
{
	double Price { get; }
	double CalculatePrice();
}
