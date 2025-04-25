using Microsoft.EntityFrameworkCore;

namespace UseSeedingSqlServerExample.Classes;

public static class Extensions
{
    /// <summary>
    /// Determines whether the specified entity type should be seeded in the database.
    /// </summary>
    /// <typeparam name="T">The type of the entity to check for seeding.</typeparam>
    /// <param name="context">The <see cref="DbContext"/> instance to check for existing data.</param>
    /// <returns>
    /// <c>true</c> if the entity type does not have any existing records in the database; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// This method is typically used during database seeding to determine whether an entity type requires initial data population.
    /// </remarks>
    public static bool ShouldSeed<T>(this DbContext context) where T : class
    {
        var set = context.Set<T>();
        return !set.Any();
    }
}