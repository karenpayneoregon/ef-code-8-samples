using CreateAndPopulateSqlServerApp.Classes;
using CreateAndPopulateSqlServerApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CreateAndPopulateSqlServerApp.Interceptors
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
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

                        if (entry.Entity is Contacts c)
                        {
                            ContactType nav = c.ContactTypeNavigation;
                            changesList.Add(new CompareModel()
                            {
                                OriginalValue = entry.OriginalValues.ToObject(),
                                NewValue = entry.CurrentValues.ToObject(),
                                EntityState = EntityState.Modified.ToString()
                            });
                        }
                        else
                        {
                            changesList.Add(new CompareModel()
                            {
                                OriginalValue = entry.OriginalValues.ToObject(),
                                NewValue = entry.CurrentValues.ToObject(),
                                EntityState = EntityState.Modified.ToString()
                            });
                        }

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
}
