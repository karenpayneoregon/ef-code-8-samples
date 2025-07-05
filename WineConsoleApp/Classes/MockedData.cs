using WineConsoleApp.Models;

namespace WineConsoleApp.Classes;

internal class MockedData
{
    /// <summary>
    /// Retrieves a predefined list of wine types.
    /// </summary>
    /// <returns>
    /// A <see cref="List{T}"/> of <see cref="WineTypes"/> objects, each representing a specific type of wine.
    /// </returns>
    /// <remarks>
    /// This method provides mock data for wine types, including their ID, name, and description.
    /// It is primarily used for seeding or testing purposes.
    /// </remarks>
    public static List<WineTypes> GetWineTypes()
    {
        return
        [
            new WineTypes() { Id = 1, TypeName = "Red", Description = "Classic red" },
            new WineTypes() { Id = 2, TypeName = "White", Description = "Dinner white" },
            new WineTypes() { Id = 3, TypeName = "Rose", Description = "Imported rose" }
        ];
    }

    /// <summary>
    /// Retrieves a list of predefined wines with their unique identifiers, names, and types.
    /// </summary>
    /// <returns>A list of <see cref="Wine"/> objects representing various wines.</returns>
    /// <remarks>
    /// This method provides mocked data for wines, which can be used for testing or seeding a database.
    /// Each wine includes its ID, name, and associated type.
    /// </remarks>
    public static List<Wine> GetWines()
    {
        return
        [
            new Wine() { WineId = 1, Name = "Veuve Clicquot Rose", WineType = WineType.Red },
            new Wine() { WineId = 2, Name = "Whispering Angel Rose", WineType = WineType.Rose },
            new Wine() { WineId = 3, Name = "Pinot Grigi", WineType = WineType.White },
            new Wine() { WineId = 4, Name = "White Zinfandel", WineType = WineType.Rose },
            new Wine() { WineId = 5, Name = "Chateau Ste. Michelle Riesling", WineType = WineType.White },
            new Wine() { WineId = 6, Name = "Robert Mondavi Cabernet Sauvignon", WineType = WineType.Red },
            new Wine() { WineId = 7, Name = "Kim Crawford Sauvignon Blanc", WineType = WineType.White },
            new Wine() { WineId = 8, Name = "Beringer White Merlot", WineType = WineType.Rose },
            new Wine() { WineId = 9, Name = "La Marca Prosecco", WineType = WineType.White },
            new Wine() { WineId = 10, Name = "Josh Cellars Pinot Noir", WineType = WineType.Red },
            new Wine() { WineId = 11, Name = "Sutter Home Moscato", WineType = WineType.White },
            new Wine() { WineId = 12, Name = "Apothic Red Blend", WineType = WineType.Red },
            new Wine() { WineId = 13, Name = "Barefoot Pink Moscato", WineType = WineType.Rose },
            new Wine() { WineId = 14, Name = "Kendall-Jackson Vintner’s Reserve Chardonnay", WineType = WineType.White },
            new Wine() { WineId = 15, Name = "Meiomi Pinot Noir", WineType = WineType.Red },
            new Wine() { WineId = 16, Name = "Ménage à Trois Red Blend", WineType = WineType.Red }
        ];
    }
}
