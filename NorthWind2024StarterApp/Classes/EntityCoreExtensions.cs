using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using NorthWind2024StarterApp.Models.Utility;

#nullable disable
namespace NorthWind2024StarterApp.Classes;
internal static class EntityCoreExtensions
{
    /// <summary>
    /// Retrieves a list of CLR types representing the entity models defined in the specified <see cref="DbContext"/>.
    /// </summary>
    /// <param name="context">The <see cref="DbContext"/> instance from which to retrieve the entity model types.</param>
    /// <returns>A list of <see cref="Type"/> objects representing the entity models.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="context"/> parameter is <c>null</c>.</exception>
    public static List<Type> GetModelNames(this DbContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        return context.Model.GetEntityTypes().Select(et => et.ClrType).ToList();
    }

    /// <summary>
    /// Retrieves a list of properties for a specified entity model within the given <see cref="DbContext"/>.
    /// </summary>
    /// <param name="context">The <see cref="DbContext"/> instance containing the entity model.</param>
    /// <param name="modelName">The name of the entity model for which to retrieve properties.</param>
    /// <returns>A list of <see cref="SqlColumn"/> objects representing the properties of the specified entity model.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="context"/> parameter is <c>null</c>.</exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the specified <paramref name="modelName"/> does not correspond to a valid entity type in the <see cref="DbContext"/>.
    /// </exception>
    public static List<SqlColumn> GetModelProperties(this DbContext context, string modelName)
    {

        if (context == null) throw new ArgumentNullException(nameof(context));

        Type? entityType = GetEntityType(context, modelName);
        bool isDict = entityType.IsGenericType && entityType.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        if (isDict)
        {
            return [];
        }

        var list = new List<SqlColumn>();

        var comments = Comments(context, modelName);

        IEnumerable<IProperty> properties = context.Model
            .FindEntityType(entityType ?? throw new InvalidOperationException())!
            .GetProperties();

        int id = 1;
        foreach (IProperty itemProperty in properties)
        {

            var comment = comments.FirstOrDefault(x => x.Name == itemProperty.Name);

            SqlColumn sqlColumn = new()
            {
                Id = id++,
                Name = itemProperty.Name,
                IsPrimaryKey = itemProperty.IsKey(),
                IsForeignKey = itemProperty.IsForeignKey(),
                IsNullable = itemProperty.IsColumnNullable(),
                ClrType  = itemProperty.PropertyInfo!.PropertyType,
                MaxLength = itemProperty.GetMaxLength() is null ? 0 : itemProperty.GetMaxLength(),
                Comment = comment
            };
            
            list.Add(sqlColumn);

        }

        return list;

    }

    /// <summary>
    /// Retrieves the CLR <see cref="Type"/> of an entity model by its name within the specified <see cref="DbContext"/>.
    /// </summary>
    /// <param name="context">The <see cref="DbContext"/> instance containing the entity models.</param>
    /// <param name="modelName">The name of the entity model to retrieve.</param>
    /// <returns>
    /// The <see cref="Type"/> of the entity model if found; otherwise, <c>null</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="context"/> parameter is <c>null</c>.</exception>
    private static Type GetEntityType(DbContext context, string modelName) =>
        context.Model.GetEntityTypes()
            .Select(eType => eType.ClrType)
            .FirstOrDefault(type => type.Name == modelName);

    /// <summary>
    /// Retrieves a collection of comments associated with the properties of a specified entity model
    /// within the provided <see cref="DbContext"/>.
    /// </summary>
    /// <param name="context">The <see cref="DbContext"/> instance containing the entity model.</param>
    /// <param name="modelName">The name of the entity model for which to retrieve property comments.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> of <see cref="ModelComment"/> objects, where each object contains
    /// the name and comment of a property in the specified entity model.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="context"/> parameter is <c>null</c>.
    /// </exception>
    public static IEnumerable<ModelComment> Comments(DbContext context, string modelName)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        var commentList = new List<ModelComment>();

        IEnumerable<IEntityType> entityTypes = context.GetService<IDesignTimeModel>()
            .Model.GetEntityTypes().Where(x => x.ClrType.Name == modelName);
        
        foreach (IEntityType entityType in entityTypes)
        {
            IEnumerable<IProperty> properties = entityType.GetProperties();
            commentList.AddRange(properties
                .Select(property => new
                {
                    property,
                    comment = property.GetAnnotations().FirstOrDefault(x => x.Name == RelationalAnnotationNames.Comment)
                })
                .Select(x =>
                    x.comment is not null
                        ? new ModelComment() { Name = x.property.Name, Comment = x.comment.Value!.ToString() }
                        : new ModelComment() { Name = x.property.Name, Comment = null }));
        }

        return commentList;

    }

}