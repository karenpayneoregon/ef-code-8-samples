
using Microsoft.EntityFrameworkCore;

namespace HasQueryFilterConditionalSample.Extensions;

public static class DbContextExtensions
{
    /// <summary>
    /// Determines whether the specified entity type has a query filter applied in the current <see cref="DbContext"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to check for a query filter.</typeparam>
    /// <param name="context">The <see cref="DbContext"/> instance to inspect.</param>
    /// <returns>
    /// <see langword="true"/> if the specified entity type has a query filter applied; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// This method checks the model metadata of the provided <see cref="DbContext"/> to determine if a query filter
    /// is defined for the specified entity type.
    /// </remarks>
    public static bool HasQueryFilter<TEntity>(this DbContext context)  where TEntity : class
    {
        var entityType = context.Model.FindEntityType(typeof(TEntity));
        return entityType?.GetQueryFilter() != null;
    }

    /// <summary>
    /// Retrieves the query filter definition for the specified entity type in the current <see cref="DbContext"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity for which the query filter definition is retrieved.</typeparam>
    /// <param name="context">The <see cref="DbContext"/> instance containing the entity type.</param>
    /// <returns>
    /// A string representation of the query filter definition if it exists; otherwise, "Unknown".
    /// </returns>
    /// <remarks>
    /// This method checks the model metadata of the specified entity type to determine if a query filter is defined.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="context"/> is <c>null</c>.
    /// </exception>
    public static string QueryFilterDefinition<TEntity>(this DbContext context) where TEntity : class
    {
        var entityType = context.Model.FindEntityType(typeof(TEntity));
        var filter = entityType?.GetQueryFilter();
        return filter?.ToString() ?? "Unknown";
    }
}

