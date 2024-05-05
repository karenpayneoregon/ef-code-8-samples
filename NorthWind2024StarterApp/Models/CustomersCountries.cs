#nullable disable
namespace NorthWind2024StarterApp.Models;

    public record CustomersCountries(int CustomerIdentifier, string CompanyName, int CountryIdentifier, string CountryName)
    {
        public override string ToString() => CompanyName;
    }

