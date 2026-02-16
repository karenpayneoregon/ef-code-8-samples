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
        var useCustomerQueryFilter = ContextSettings.Instance.CustomerOptions.UseQueryFilter;

        using var context = new Context();

        var count = context.Customers
            .TagWithDebugInfo($"With ignore filter {useCustomerQueryFilter.ToYesNo()}")
            .Count();

        if (useCustomerQueryFilter)
        {
            var countryId = ContextSettings.Instance.CustomerOptions.CountryCode;
            var country = context.Countries.FirstOrDefault(c => c.CountryIdentifier == countryId);
            if (country == null)
            {
                SpectreConsoleHelpers.ErrorPill(Justify.Left, $"Country with id {countryId} not found");
                SpectreConsoleHelpers.ExitPrompt(Justify.Left);
                return;
            }
            SpectreConsoleHelpers.PinkPill(Justify.Left, $"Count {count} with query filter on {country?.Name} ");
        }
        else
        {
            SpectreConsoleHelpers.PinkPill(Justify.Left, $"Count {count} w/o query filter");
        }

        Console.WriteLine();

        var categoryOptions = ContextSettings.Instance.CategoryOptions;
        var categoryCount = context.Categories.Count();

        SpectreConsoleHelpers.PinkPill(Justify.Left, $"Category options: Use filter " +
                                                     $"{categoryOptions.UseQueryFilter.ToYesNo()} " +
                                                     $"category id {categoryOptions.Id} Count {categoryCount}");

        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }
}
