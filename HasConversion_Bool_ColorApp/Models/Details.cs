namespace HasConversion_Bool_ColorApp.Models;

/// <summary>
/// Represents the details of a project, including company, copyright, product, description, and version information.
/// </summary>
public class Details
{
    public required string Company { get; set; }
    public required string Copyright { get; set; }
    public required string Product { get; set; }
    public required string Description { get; set; }
    public required string Version { get; set; }
    public required string BuildDate { get; set; }
}