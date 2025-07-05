namespace WineConsoleApp.Models;
internal class ApplicationSettings
{
    /// <summary>
    /// Gets or sets a value indicating whether mocked data should be used in the application.
    /// </summary>
    /// <remarks>
    /// When set to <c>true</c>, the application will utilize predefined mocked data for operations 
    /// such as database seeding. When set to <c>false</c>, the application will rely on actual data sources.
    /// </remarks>
    public bool UseMockedData { get; set; }
}
