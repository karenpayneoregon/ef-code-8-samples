namespace ExecuteUpdateDeleteSampleApp.Models;

public class CustomerWithStores
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Region { get; set; }
    public string? Tag { get; set; }
}