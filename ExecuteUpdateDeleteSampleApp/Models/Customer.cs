namespace ExecuteUpdateDeleteSampleApp.Models;

public class Customer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required CustomerInfo CustomerInfo { get; set; }
}

[Owned]
public class CustomerInfo
{
    public string? Tag { get; set; }
}