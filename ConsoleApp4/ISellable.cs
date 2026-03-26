using System;

public interface ISellable
{
	double Price { get; }
	string GetSalesSummary();
}
