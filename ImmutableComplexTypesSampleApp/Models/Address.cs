namespace ImmutableComplexTypesSampleApp.Models;

public class Address(string line1, string? line2, string city, string country, string postCode)
{
    public string Line1 { get; } = line1;
    public string? Line2 { get; } = line2;
    public string City { get; } = city;
    public string Country { get; } = country;
    public string PostCode { get; } = postCode;
}