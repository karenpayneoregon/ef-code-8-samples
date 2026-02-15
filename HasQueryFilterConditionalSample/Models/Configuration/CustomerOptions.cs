namespace HasQueryFilterConditionalSample.Models.Configuration;

/// <summary>
/// Represents configuration options specific to customer-related operations.
/// </summary>
/// <remarks>
/// This class provides properties to configure customer-specific settings, such as enabling query filters 
/// or specifying country codes. These settings are typically used to customize the behavior of customer 
/// operations within the application.
/// </remarks>
public class CustomerOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether to apply a query filter for customers. The value is read from appsettings.json
    /// </summary>
    /// <value>
    /// <c>true</c> if the query filter should be applied; otherwise, <c>false</c>.
    /// </value>
    public bool UseQueryFilter { get; set; }

    /// <summary>
    /// Gets or sets the country code used to filter customers based on their country. The value is read from appsettings.json
    /// </summary>
    /// <remarks>
    /// This property is utilized in query filters to match customers with a specific country identifier.
    /// </remarks>
    public int CountryCode { get; set; }
}