using UseSeedingSqlServerExample.Models;

namespace UseSeedingSqlServerExample.Classes;

/// <summary>
/// Provides mocked data for seeding purposes in the application.
/// </summary>
/// <remarks>
/// This class contains methods to retrieve predefined data for entities such as manufacturers and cars.
/// It is primarily used to populate the database with initial data during development or testing.
/// </remarks>
public class MockedData
{
    /// <summary>
    /// Retrieves a list of predefined manufacturers for seeding purposes.
    /// </summary>
    /// <remarks>
    /// Each manufacturer in the list includes basic details such as the name.
    /// This method is typically used to populate initial manufacturer data into the database.
    /// </remarks>
    /// <returns>A list of <see cref="Manufacturer"/> objects representing predefined manufacturer data.</returns>
    public static List<Manufacturer> GetManufacturers() =>
    [
        new() { Name = "Toyota" },
        new() { Name = "Ford" },
        new() { Name = "Mazda" }
    ];

    /// <summary>
    /// Retrieves a list of predefined cars for seeding purposes.
    /// </summary>
    /// <remarks>
    /// Each car in the list includes details such as make, model, year, and associated manufacturer ID.
    /// This method is typically used to populate initial data into the database.
    /// </remarks>
    /// <returns>A list of <see cref="Car"/> objects representing predefined car data.</returns>
    public static List<Car> GetCars() =>
    [
        new() { Make = "MX5", Model = "Miata", YearOf = 2025, ManufacturerId = 3 },
        new() { Make = "Mustang", Model = "GT", YearOf = 2023, ManufacturerId = 2 },
        new() { Make = "Corolla", Model = "GR", YearOf = 2022, ManufacturerId = 1 }
    ];
}
