using HierarchyIdSampleApp.Data;
using HierarchyIdSampleApp.Models;
using static HierarchyIdSampleApp.Classes.DataConnections;
using static UtilityLibarary.SpectreConsoleHelpers;

namespace HierarchyIdSampleApp.Classes;
internal class Operations
{
    public static async Task SQL_Server_HierarchyId()
    {
        PrintCyan();

        await using var context = new Context(Instance.MainConnection);
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        await context.Seed();

        RunningMessage("Database created");

        var level = 0;
        while (true)
        {
            #region GetLevel
            var generation = await context.Halflings.Where(halfling => halfling.PathFromPatriarch.GetLevel() == level).ToListAsync();
            #endregion

            if (!generation.Any())
            {
                break;
            }

            RunningMessage($"Generation {level}: ");

            for (var index = 0; index < generation.Count; index++)
            {
                var halfling = generation[index];
                Console.Write($"{halfling.Name}");
                if (index < generation.Count - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine();

            level++;
        }

        var directAncestor = (await FindDirectAncestor("Bilbo"))!;
        Console.WriteLine();
        RunningMessage($"The direct ancestor of Bilbo is {directAncestor.Name}");

        #region FindDirectAncestor
        async Task<Halfling?> FindDirectAncestor(string name)
            => await context.Halflings
                .SingleOrDefaultAsync(
                    ancestor => ancestor.PathFromPatriarch == context.Halflings
                        .Single(descendent => descendent.Name == name).PathFromPatriarch
                        .GetAncestor(1));
        #endregion

        Console.WriteLine();
        var ancestors = await FindAllAncestors("Bilbo").AsNoTracking().ToListAsync();

        Console.WriteLine();
        RunningMessage("Ancestors of Bilbo are:");
        foreach (var halfling in ancestors)
        {
            Console.WriteLine($"     {halfling.Name}");
        }

        #region FindAllAncestors
        IQueryable<Halfling> FindAllAncestors(string name)
            => context.Halflings.Where(
                    ancestor => context.Halflings
                        .Single(
                            descendent =>
                                descendent.Name == name
                                && ancestor.Id != descendent.Id)
                        .PathFromPatriarch.IsDescendantOf(ancestor.PathFromPatriarch))
                .OrderByDescending(ancestor => ancestor.PathFromPatriarch.GetLevel());
        #endregion

        Console.WriteLine();
        var directDescendents = await FindDirectDescendents("Mungo").AsNoTracking().ToListAsync();

        Console.WriteLine();
        RunningMessage("Direct descendents of Mungo:");
        foreach (var descendent in directDescendents)
        {
            Console.WriteLine($"     {descendent.Name}");
        }

        #region FindDirectDescendents
        IQueryable<Halfling> FindDirectDescendents(string name)
            => context.Halflings.Where(
                descendent => descendent.PathFromPatriarch.GetAncestor(1) == context.Halflings
                    .Single(ancestor => ancestor.Name == name).PathFromPatriarch);
        #endregion

        Console.WriteLine();
        var descendents = await FindAllDescendents("Mungo").AsNoTracking().ToListAsync();

        Console.WriteLine();
        RunningMessage("All descendents of Mungo:");
        foreach (var descendent in descendents)
        {
            Console.WriteLine($"     {descendent.Name}");
        }

        #region FindAllDescendents
        IQueryable<Halfling> FindAllDescendents(string name)
            => context.Halflings.Where(
                    descendent => descendent.PathFromPatriarch.IsDescendantOf(
                        context.Halflings
                            .Single(
                                ancestor =>
                                    ancestor.Name == name
                                    && descendent.Id != ancestor.Id)
                            .PathFromPatriarch))
                .OrderBy(descendent => descendent.PathFromPatriarch.GetLevel());
        #endregion

        Console.WriteLine();
        RunningMessage("All descendents of Ponto:");
        foreach (var descendent in await FindAllDescendents("Ponto").AsNoTracking().ToListAsync())
        {
            Console.WriteLine($"     {descendent.Name}");
        }

        var mungo = await context.Halflings.SingleAsync(halfling => halfling.Name == "Mungo");
        var ponto = await context.Halflings.SingleAsync(halfling => halfling.Name == "Ponto" && halfling.YearOfBirth == 1216);

        #region LongoAndDescendents
        var longoAndDescendents = await context.Halflings.Where(
                descendent => descendent.PathFromPatriarch.IsDescendantOf(
                    context.Halflings.Single(ancestor => ancestor.Name == "Longo").PathFromPatriarch))
            .ToListAsync();
        #endregion

        Console.WriteLine();
        RunningMessage("Reparenting of Longo from Mungo to Ponto:");
        Console.WriteLine();


        #region GetReparentedValue
        foreach (var descendent in longoAndDescendents)
        {
            descendent.PathFromPatriarch
                = descendent.PathFromPatriarch.GetReparentedValue(
                    mungo.PathFromPatriarch, ponto.PathFromPatriarch)!;
        }

        await context.SaveChangesAsync();
        #endregion

        Console.WriteLine();
        RunningMessage("All descendents of Mungo:");
        foreach (var descendent in await FindAllDescendents("Mungo").AsNoTracking().ToListAsync())
        {
            Console.WriteLine($"     {descendent.Name}");
        }

        Console.WriteLine();
        RunningMessage("All descendents of Ponto:");
        foreach (var descendent in await FindAllDescendents("Ponto").AsNoTracking().ToListAsync())
        {
            Console.WriteLine($"     {descendent.Name}");
        }

        Console.WriteLine();

        var bilbo = await context.Halflings.SingleAsync(halfling => halfling.Name == "Bilbo");
        var frodo = await context.Halflings.SingleAsync(halfling => halfling.Name == "Frodo");

        var commonAncestor = (await FindCommonAncestor(bilbo, frodo))!;
        Console.WriteLine();
        RunningMessage($"The common ancestor of Bilbo and Frodo is {commonAncestor.Name}");

        #region FindCommonAncestor
        async Task<Halfling?> FindCommonAncestor(Halfling first, Halfling second)
            => await context.Halflings
                .Where(
                    ancestor => first.PathFromPatriarch.IsDescendantOf(ancestor.PathFromPatriarch)
                                && second.PathFromPatriarch.IsDescendantOf(ancestor.PathFromPatriarch))
                .OrderByDescending(ancestor => ancestor.PathFromPatriarch.GetLevel())
                .FirstOrDefaultAsync();
        #endregion

        
        RunningMessage("Done");
    }
}
