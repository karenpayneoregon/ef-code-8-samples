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
    /// Gets the list of available gender types.
    /// </summary>
    /// <returns>A list of <see cref="GenderData"/> objects representing the gender types.</returns>
    public static List<GenderData> GenderTypes() =>
    [
        new GenderData { Id = 1, Name = "Male" },
        new GenderData { Id = 2, Name = "Female" }
    ];

    /// <summary>
    /// Generates a consistent list of people.
    /// </summary>
    /// <param name="count">The number of people to generate.</param>
    /// <param name="seed">The seed value for repeatable data. Default is 338.</param>
    /// <returns>A list of <see cref="BirthDays"/> objects with repeatable people.</returns>
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

