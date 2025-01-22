using SetPropertyValuesSample.Models;

namespace SetPropertyValuesSample.Classes;
public static class MockedData
{
    /// <summary>
    /// Data to seed Person table
    /// </summary>
    /// <returns></returns>
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
            }
        ];

}
