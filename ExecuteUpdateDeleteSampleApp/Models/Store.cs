namespace ExecuteUpdateDeleteSampleApp.Models;

public class Store
{
    public int Id { get; set; }
    public List<CustomerWithStores> Customers { get; } = new();
    public string? Region { get; set; }
}