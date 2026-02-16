using HasQueryFilterConditionalSample.Models.Configuration;
using Microsoft.Extensions.Configuration;

namespace HasQueryFilterConditionalSample.Classes.Configuration;
/// <summary>
/// Represents the configuration settings for the application's database context.
/// </summary>
/// <remarks>
/// This class implements the singleton pattern to ensure a single instance is used throughout the application.
/// It retrieves and binds configuration settings from the application's configuration file to initialize its properties.
/// </remarks>
public sealed class ContextSettings
{
    private static readonly Lazy<ContextSettings> Lazy = new Lazy<ContextSettings>(() => new ContextSettings());

    public static ContextSettings Instance => ContextSettings.Lazy.Value;

    /// <summary>
    /// Gets or sets a value indicating whether the audit interceptor should be enabled.
    /// </summary>
    /// <remarks>
    /// The audit interceptor is used to track and log changes made to the database context.
    /// This property is configured based on the <c>UseAuditInterceptor</c> setting in the application's configuration file.
    /// </remarks>
    public bool UseAuditInterceptor { get; set; }

    /// <summary>
    /// Gets or sets the configuration options related to customers.
    /// </summary>
    /// <remarks>
    /// This property is initialized from the <c>Customers</c> section of the application configuration file.
    /// It provides settings such as whether to use query filters for customer-related operations.
    /// </remarks>
    public CustomerOptions CustomerOptions { get; set; }

    /// <summary>
    /// Gets or sets the configuration options specific to category-related operations.
    /// </summary>
    /// <remarks>
    /// This property provides access to settings that customize the behavior of category operations, 
    /// such as enabling query filters or specifying identifiers. These options are typically used 
    /// to configure how categories are handled within the application's database context.
    /// </remarks>
    public CategoryOptions CategoryOptions { get; set; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ContextSettings"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor is private to enforce the singleton pattern.
    /// It retrieves configuration settings from the application's configuration file
    /// and binds them to the <see cref="ContextOptions"/> class. The settings are then
    /// used to initialize the <see cref="UseAuditInterceptor"/> and <see cref="CustomerOptions"/> properties.
    /// 
    /// <br/><br/>
    /// <para>
    ///    For a real application, you might want to consider <a href="https://dev.to/karenpayneoregon/aspnet-core-startup-validation-20e7">ValidateOnStart</a>
    /// </para>
    /// </remarks>
    private ContextSettings()
    {
        // Config is set up in the project file to bind the configuration
        // to the ContextOptions class, so we can directly retrieve it here.
        ContextOptions options = Config.Configuration.JsonRoot()
            .GetSection(nameof(ContextOptions))
            .Get<ContextOptions>()!;

        CustomerOptions = options.CustomersOptions;
        CategoryOptions = options.CategoryOptions;
 
    }

}
