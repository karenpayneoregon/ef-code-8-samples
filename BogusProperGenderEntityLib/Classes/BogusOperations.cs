using Bogus;
using Bogus.DataSets;
using BogusProperGenderEntityLib.Models;

// ReSharper disable MethodOverloadWithOptionalParameter

namespace BogusProperGenderEntityLib.Classes;

/// <summary>
/// Provides operations for generating bogus data.
/// </summary>
public class BogusOperations
{
    /// <summary>
    /// Retrieves a predefined list of gender types.
    /// </summary>
    /// <returns>
    /// A list of <see cref="GenderData"/> objects, where each object represents
    /// a gender type with properties such as <c>Id</c> and <c>Name</c>.
    /// </returns>
    /// <remarks>
    /// This method provides a static list of gender types, including "Male" and "Female".
    /// It is primarily used for seeding or mocking data in the application.
    /// </remarks>
    public static List<GenderData> GenderTypes() =>
    [
        new GenderData { Id = 1, Name = "Male" },
        new GenderData { Id = 2, Name = "Female" }
    ];

    /// <summary>
    /// Generates a list of people with consistent and repeatable data.
    /// </summary>
    /// <param name="count">The number of people to generate.</param>
    /// <param name="seed">
    /// The seed value used for generating repeatable data. 
    /// Defaults to <c>338</c> if not specified.
    /// </param>
    /// <returns>
    /// A list of <see cref="BirthDays"/> objects, each representing a person 
    /// with properties such as name, gender, birthdate, and email.
    /// </returns>
    /// <remarks>
    /// This method uses the Bogus library to generate mock data. The generated
    /// data includes a unique identifier, gender, first name, last name, birthdate,
    /// and email address for each person.
    /// </remarks>
    public static List<BirthDays> PeopleList(int count, int seed = 338)
    {
        var identifier = 1;
        Randomizer.Seed = new Random(seed);

        var faker = new Faker<BirthDays>().Rules((f, b) =>
        {
            b.Id = identifier++;
            b.Gender = f.PickRandom<Gender>();
            b.FirstName = f.Name.FirstName((Name.Gender?)b.Gender);
            b.LastName = f.Name.LastName();
            b.BirthDate = f.Date.BetweenDateOnly(
                new DateOnly(1950, 1, 1), 
                new DateOnly(2010, 1, 1));
            b.Email = f.Internet.Email(b.FirstName, b.LastName);
        });

        return faker.Generate(count);
    }
}

