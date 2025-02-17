namespace WineConsoleApp.Models;
#nullable disable
/// <summary>
/// Represents a wine with its unique identifier, name, and type.
/// </summary>
/// <remarks>
/// This class provides a basic representation of a wine, including its ID, name, and associated type.
/// It also overrides the <see cref="ToString"/> method to return a formatted string combining the wine type and name.
/// </remarks>
public class Wine
{
    /// <summary>
    /// Gets or sets the unique identifier for the wine.
    /// </summary>
    /// <value>
    /// An integer representing the unique ID of the wine.
    /// </value>
    /// <remarks>
    /// This property is used as the primary key for the <see cref="Wine"/> entity in the database.
    /// </remarks>
    public int WineId { get; set; }
    /// <summary>
    /// Gets or sets the name of the wine.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the name of the wine.
    /// </value>
    /// <remarks>
    /// This property holds the name of the wine, which is used in combination with the wine type
    /// to provide a formatted string representation in the <see cref="ToString"/> method.
    /// </remarks>
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets the type of the wine.
    /// </summary>
    /// <remarks>
    /// The <see cref="WineType"/> property represents the classification of the wine, 
    /// such as Red, White, or Rose. This property is mapped to an integer value in the database.
    /// </remarks>
    public WineType WineType { get; set; }
    public override string ToString() => $"{WineType} {Name}";
}