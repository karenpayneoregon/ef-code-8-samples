using NorthWind2024StarterApp.Data;
using NorthWind2024StarterApp.Models.Utility;

namespace NorthWind2024StarterApp.Classes;
internal class EntityOperations
{
    /// <summary>
    /// Retrieves a list of entity details, including their names and associated columns, from the database context.
    /// </summary>
    /// <remarks>
    /// This method uses the <see cref="Context"/> to fetch metadata about entity models and their properties.
    /// It constructs a list of <see cref="EntityItem"/> objects, each representing an entity and its associated columns.
    /// </remarks>
    /// <returns>
    /// A list of <see cref="EntityItem"/> objects, where each item contains the name of an entity and its associated columns.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the database context or any required data is <c>null</c>.
    /// </exception>
    /// <example>
    /// The following example demonstrates how to use this method:
    /// <code>
    /// var entityDetails = EntityOperations.ModelDetails();
    /// foreach (var entity in entityDetails)
    /// {
    ///     Console.WriteLine($"Entity: {entity.Name}, Columns: {string.Join(", ", entity.Columns)}");
    /// }
    /// </code>
    /// </example>
    public static List<EntityItem> ModelDetails()
    {
        List<EntityItem> entityListItems = [];


        using var context = new Context();
        var models = context.GetModelNames();

        entityListItems.AddRange(models.Select(model => new
            {
                model,
                columns = context.GetModelProperties(model.Name)
            })
            .Where(mc => mc.columns.Any())
            .Select(mc => new EntityItem { Name = mc.model.Name, Columns = mc.columns.ToList() }));

        return entityListItems;
    }
}
