using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Xml.Linq;
#nullable disable
namespace NorthWind2024StarterApp.Classes;
internal static class EntityCoreExtensions
{
    public static List<Type> GetModelNames(this DbContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        return context.Model.GetEntityTypes().Select(et => et.ClrType).ToList();
    }
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

    private static Type? GetEntityType(DbContext context, string modelName) =>
        context.Model.GetEntityTypes()
            .Select(eType => eType.ClrType)
            .FirstOrDefault(type => type.Name == modelName);

    public static IEnumerable<ModelComment> Comments(DbContext context, string modelName)
    {

        if (context == null) throw new ArgumentNullException(nameof(context));

        var commentList = new List<ModelComment>();

        IEnumerable<IEntityType> entityTypes = context.GetService<IDesignTimeModel>()
            .Model.GetEntityTypes()
            .Where(x => x.ClrType.Name == modelName);


        foreach (IEntityType entityType in entityTypes)
        {
            IEnumerable<IProperty> properties = entityType.GetProperties();
            commentList.AddRange(properties
                .Select(property => new
                {
                    property,
                    comment = property.GetAnnotations().FirstOrDefault(x => 
                        x.Name == RelationalAnnotationNames.Comment)
                })
                .Select(x =>
                    x.comment is not null
                        ? new ModelComment() { Name = x.property.Name, Comment = x.comment.Value!.ToString() }
                        : new ModelComment() { Name = x.property.Name, Comment = null }));
        }

        return commentList;

    }

}

public class ModelComment
{
    /// <summary>
    /// Property name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Comment value
    /// </summary>
    public string Comment { get; set; }
    public string Full => $"{Name}, {Comment}";
    public override string ToString() => Name;

}
public class EntityItem
{
    public string Name { get; set; }
    public List<SqlColumn> Columns { get; set; } = [];
    public override string ToString() => Name;

}

public class SqlColumn
{
    public bool IsPrimaryKey { get; set; }
    public bool IsForeignKey { get; set; }
    public bool IsNullable { get; set; }
    /// <summary>
    /// Column/property name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Description/comment from table definition in database table
    /// </summary>
    public string Description => Comment?.Comment ?? "No comment";
    public int Id { get; set; }
    public Type ClrType { get; set; }

    public int? MaxLength { get; set; }
    public ModelComment Comment { get; set; }

    public override string ToString() => Name;

}
