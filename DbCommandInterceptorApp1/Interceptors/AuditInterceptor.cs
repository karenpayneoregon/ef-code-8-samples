using DbCommandInterceptorApp1.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DbCommandInterceptorApp1.Interceptors;

/// <summary>
/// Represents an interceptor that audits changes made to the database context during save operations.
/// </summary>
/// <remarks>
/// This class extends <see cref="Microsoft.EntityFrameworkCore.Diagnostics.SaveChangesInterceptor"/> 
/// to inspect and log changes to entities in the database context. It captures added, modified, 
/// and deleted entities, serializes the changes, and writes them to a JSON file for auditing purposes.
/// </remarks>
public class AuditInterceptor : SaveChangesInterceptor
{
    /// <summary>
    /// Intercepts the asynchronous save operation in the database context to inspect and audit changes.
    /// </summary>
    /// <param name="eventData">
    /// The event data associated with the save operation, containing information about the context and changes.
    /// </param>
    /// <param name="result">
    /// The result of the save operation, which can be modified or inspected.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous operation, containing the interception result.
    /// </returns>
    /// <remarks>
    /// This method overrides <see cref="Microsoft.EntityFrameworkCore.Diagnostics.SaveChangesInterceptor.SavingChangesAsync"/> 
    /// to capture and log changes made to entities in the database context during save operations. It inspects the 
    /// change tracker entries for added, modified, and deleted entities, and processes them for auditing purposes.
    /// </remarks>
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = new CancellationToken())
    {
        Inspect(eventData);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }


    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        Inspect(eventData);
        return base.SavingChanges(eventData, result);
    }

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        Inspect(eventData);
        return base.SavedChanges(eventData, result);
    }

    private static void Inspect(DbContextEventData eventData)
    {
        var changesList = new List<CompareModel>();
        var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json", $"{DateTime.Now:yyyyMMdd}.json");

        foreach (EntityEntry entry in eventData.Context!.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    changesList.Add(new CompareModel()
                    {
                        OriginalValue = null,
                        NewValue = entry.CurrentValues.ToObject(),
                        EntityState = EntityState.Added.ToString()
                    });
                    break;
                case EntityState.Deleted:
                    changesList.Add(new CompareModel()
                    {
                        OriginalValue = entry.OriginalValues.ToObject(),
                        NewValue = null,
                        EntityState = EntityState.Deleted.ToString()
                    });
                    break;
                case EntityState.Modified:

                    changesList.Add(new CompareModel()
                    {
                        OriginalValue = entry.OriginalValues.ToObject(),
                        NewValue = entry.CurrentValues.ToObject(),
                        EntityState = EntityState.Modified.ToString()
                    });

                    break;
            }


            List<CompareModel> data = changesList.AppendFromFile(fileName);
            data.ToJson(DateTime.Now.ToString("yyyyMMdd"));
            changesList.Clear();
        }
    }

    private class CompareModel
    {
        public object OriginalValue { get; set; }

        public object NewValue { get; set; }
        public string EntityState { get; set; }
    }
}