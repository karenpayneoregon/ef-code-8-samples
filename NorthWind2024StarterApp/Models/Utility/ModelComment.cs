#nullable disable
using NorthWind2024StarterApp;

namespace NorthWind2024StarterApp.Models.Utility;

/// <summary>
/// Represents a comment associated with a property of an entity model.
/// </summary>
/// <remarks>
/// This class is used to store metadata about a property, including its name and an optional comment.
/// It is typically utilized in scenarios where entity model metadata, such as property descriptions,
/// needs to be retrieved or displayed.
/// </remarks>
public class ModelComment
{
    /// <summary>
    /// Property name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Comment value
    /// </summary>
    public string Comment { get; set; }
    public string Full => $"{Name}, {Comment}";
    public override string ToString() => Name;

}