using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExecuteUpdateSampleApp.Classes;
// https://stackoverflow.com/questions/75924095/how-to-conditionally-setproperty-with-entity-framework-core-executeupdate
// TODO
public static class QueryableExecutePatchUpdateExtensions
{
    public static Task<int> ExecutePatchUpdateAsync<TSource>(this IQueryable<TSource> source,
        Action<SetPropertyBuilder<TSource>> setPropertyBuilder, CancellationToken ct = default)
    {
        var builder = new SetPropertyBuilder<TSource>();
        setPropertyBuilder.Invoke(builder);
        return source.ExecuteUpdateAsync(builder.SetPropertyCalls, ct);
    }

    public static int ExecutePatchUpdate<TSource>(this IQueryable<TSource> source, Action<SetPropertyBuilder<TSource>> setPropertyBuilder)
    {
        var builder = new SetPropertyBuilder<TSource>();
        setPropertyBuilder.Invoke(builder);
        return source.ExecuteUpdate(builder.SetPropertyCalls);
    }
}

public class SetPropertyBuilder<TSource>
{
    public Expression<Func<SetPropertyCalls<TSource>, SetPropertyCalls<TSource>>> SetPropertyCalls { get; private set; } = b => b;

    public SetPropertyBuilder<TSource> SetProperty<TProperty>(Expression<Func<TSource, TProperty>> propertyExpression, TProperty value) 
        => SetProperty(propertyExpression, _ => value);

    public SetPropertyBuilder<TSource> SetProperty<TProperty>(Expression<Func<TSource, TProperty>> propertyExpression, Expression<Func<TSource, TProperty>> valueExpression)
    {
        SetPropertyCalls = SetPropertyCalls.Update(
            body: Expression.Call(instance: SetPropertyCalls.Body,
                methodName: nameof(SetPropertyCalls<TSource>.SetProperty),
                typeArguments: new[] { typeof(TProperty) },
                arguments: new Expression[] { propertyExpression, valueExpression }
            ),
            parameters: SetPropertyCalls.Parameters
        );

        return this;
    }
}