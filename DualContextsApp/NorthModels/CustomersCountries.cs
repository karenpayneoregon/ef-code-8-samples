#nullable disable
namespace DualContextsApp.NorthModels;

    public record CustomersCountries(int CustomerIdentifier, string CompanyName, int CountryIdentifier, string CountryName)
    {
        public override string ToString() => CompanyName;
    }

