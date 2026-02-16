namespace HasQueryFilterConditionalSample.Models.Configuration;

/// <summary>
/// Represents configuration options specific to category-related operations.
/// </summary>
/// <remarks>
/// This class provides properties to configure category-specific settings, such as enabling query filters 
/// or specifying identifiers. These settings are typically used to customize the behavior of category 
/// operations within the application.
/// </remarks>
public class CategoryOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether query filters should be applied to category-related queries.
    /// </summary>
    /// <value>
    /// <c>true</c> if query filters are enabled; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// When enabled, query filters are applied to restrict the results of category-related queries 
    /// based on the specified conditions. This setting is typically used to enforce application-specific 
    /// filtering logic.
    /// </remarks>
    public bool UseQueryFilter { get; set; }
    /// <summary>
    /// Gets or sets the unique identifier for the category HasQueryFilter.
    /// </summary>
    /// <remarks>
    /// This property is used to specify the identifier for category-related operations, 
    /// such as applying query filters in the database context.
    /// </remarks>
    public int Id { get; set; }
}