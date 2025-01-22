using SetPropertyValuesSample.Models;

namespace SetPropertyValuesSample.Classes;
/// <summary>
/// Provides mocked data for use in the application, including predefined lists of <see cref="Person"/> objects.
/// </summary>
public static class MockedData
{

    /// <summary>
    /// Provides a list of mocked <see cref="Person"/> objects.
    /// </summary>
    /// <returns>A list of <see cref="Person"/> objects with predefined data.</returns>
    public static List<Person> PeopleList()
        =>
        [
            new()
            {
                Id = 1,
                Title = "Miss",
                FirstName = "Karen",
                LastName = "Payne",
                BirthDate = new DateOnly(1956, 9, 24)
            },
            new() 
            {
                Id = 2,
                Title = "Mr",
                FirstName = "Bob",
                LastName = "Smith",
                BirthDate = new DateOnly(1960, 2, 12)

            }, 
            new()
            {
                Id = 3,
                Title = "Mr",
                FirstName = "Jim",
                LastName = "Lebow",
                BirthDate = new DateOnly(1950, 4, 9)
            },
            new()
            {
                Id = 4,
                Title = "Mrs",
                FirstName = "Emily",
                LastName = "Johnson",
                BirthDate = new DateOnly(1985, 7, 15)
            },
            new()
            {
                Id = 5,
                Title = "Dr",
                FirstName = "Michael",
                LastName = "Brown",
                BirthDate = new DateOnly(1975, 11, 22)
            },
            new()
            {
                Id = 6,
                Title = "Ms",
                FirstName = "Sophia",
                LastName = "Clark",
                BirthDate = new DateOnly(1990, 3, 5)
            },
            new()
            {
                Id = 7,
                Title = "Mr",
                FirstName = "Daniel",
                LastName = "Davis",
                BirthDate = new DateOnly(1980, 6, 30)
            },
            new()
            {
                Id = 8,
                Title = "Miss",
                FirstName = "Olivia",
                LastName = "Martinez",
                BirthDate = new DateOnly(1995, 10, 10)
            },
            new()
            {
                Id = 9,
                Title = "Mr",
                FirstName = "Christopher",
                LastName = "Wilson",
                BirthDate = new DateOnly(1965, 1, 18)
            },
            new()
            {
                Id = 10,
                Title = "Dr",
                FirstName = "Elizabeth",
                LastName = "Moore",
                BirthDate = new DateOnly(1970, 8, 25)
            }
        ];


}
