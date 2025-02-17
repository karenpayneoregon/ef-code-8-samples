#nullable disable
using NorthWind2024StarterApp;

namespace NorthWind2024StarterApp.Models.Utility;

/// <summary>
/// Represents an entity item that encapsulates the name of an entity and its associated columns.
/// </summary>
/// <remarks>
/// This class is primarily used to model and manage metadata about entities, including their names
/// and the properties (columns) they contain. It is utilized in operations that involve retrieving
/// and displaying entity details.
/// </remarks>
public class EntityItem
{
    public string Name { get; set; }
    public List<SqlColumn> Columns { get; set; } = [];
    public override string ToString() => Name;

}