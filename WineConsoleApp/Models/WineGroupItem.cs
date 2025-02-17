namespace WineConsoleApp.Models;
/// <summary>
/// Represents a grouping of wines by their type.
/// </summary>
/// <remarks>
/// This class is designed to group wines based on their <see cref="WineType"/> and provides access to the grouped list of wines.
/// </remarks>
public class WineGroupItem(WineType key, List<Wine> list)
{
    public WineType Key { get; } = key;
    public List<Wine> List { get; } = list;
}