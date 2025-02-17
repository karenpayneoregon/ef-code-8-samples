#nullable disable
using NorthWind2024StarterApp;

namespace NorthWind2024StarterApp.Models.Utility;

/// <summary>
/// Represents a column in a database table, providing metadata such as its name, type, 
/// whether it is a primary or foreign key, and additional attributes like nullability and maximum length.
/// </summary>
/// <remarks>
/// This class is used to encapsulate the properties and metadata of a database column, 
/// including its relationship to other entities and its descriptive comment.
/// </remarks>
public class SqlColumn
{
    public bool IsPrimaryKey { get; set; }
    public bool IsForeignKey { get; set; }
    public bool IsNullable { get; set; }
    /// <summary>
    /// Column/property name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Description/comment from table definition in database table
    /// </summary>
    public string Description => Comment?.Comment ?? "No comment";
    public int Id { get; set; }
    public Type ClrType { get; set; }

    public int? MaxLength { get; set; }
    public ModelComment Comment { get; set; }

    public override string ToString() => Name;

}