using HasQueryFilterConditionalSample.Classes.Configuration;
using HasQueryFilterConditionalSample.Classes.Core;
using HasQueryFilterConditionalSample.Data;
using HasQueryFilterConditionalSample.Extensions;
using Spectre.Console;

namespace HasQueryFilterConditionalSample;
internal partial class Program
{
    static void Main(string[] args)
    {
        var useQueryFilter = ContextSettings.Instance.CustomerOptions.UseQueryFilter;

        using var context = new Context();

        var count = context.Customers
            .TagWithDebugInfo($"With ignore filter {useQueryFilter.ToYesNo()}")
            .Count();

        if (useQueryFilter)
        {
            var countryId = ContextSettings.Instance.CustomerOptions.CountryCode;
            var country = context.Countries.FirstOrDefault(c => c.CountryIdentifier == countryId);
            if (country == null)
            {
                SpectreConsoleHelpers.ErrorPill(Justify.Left, $"Country with id {countryId} not found");
                SpectreConsoleHelpers.ExitPrompt(Justify.Left);
                return;
            }
            SpectreConsoleHelpers.PinkPill(Justify.Left, $"{count} with query filter on {country?.Name} ");
        }
        else
        {
            SpectreConsoleHelpers.PinkPill(Justify.Left, $"{count} w/o query filter");
        }
        
        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }
}
