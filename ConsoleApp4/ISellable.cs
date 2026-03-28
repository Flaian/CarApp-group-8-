namespace CarAppGroup8
{
    public interface ISellable
    {
        double Price { get; }
        string GetSalesSummary();
    }
}
