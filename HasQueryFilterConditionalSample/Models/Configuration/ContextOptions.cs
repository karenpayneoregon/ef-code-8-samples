namespace HasQueryFilterConditionalSample.Models.Configuration;
public class ContextOptions
{

    /// <summary>
    /// Gets or sets the configuration options for customers model.
    /// </summary>
    /// <remarks>
    /// This property provides access to the <see cref="CustomerOptions"/> class, 
    /// which contains specific settings related to customer operations, such as enabling 
    /// query filters or other customer-specific configurations.
    /// </remarks>
    public CustomerOptions CustomersOptions { get; set; } = new();
    public CategoryOptions CategoryOptions { get; set; } = new();
}