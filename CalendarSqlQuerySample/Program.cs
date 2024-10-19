using CalendarSqlQuerySample.Classes;
using CalendarSqlQuerySample.Classes.DatabaseClasses;
using CalendarSqlQuerySample.Data;
using Microsoft.EntityFrameworkCore;
#pragma warning disable EF1002

namespace CalendarSqlQuerySample;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();
        
        await using var context = new Context();

        int year = DateTime.Now.Year;

        //await TheSolution(context, year);
        await TheSolutionStoredProcedureFormated(context, year);
        await RawExampleUnprotected(context, year);
        //await NormalStatement(context, year);

        ExitPrompt();

    }

    /// <summary>
    /// Executes a normal LINQ statement to retrieve holidays for a specific year.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="year">The year to retrieve holidays for.</param>
    private static async Task NormalStatement(Context context, int year)
    {
        
        var currentYear = await context.Calendar
            .Where(x => x.CalendarYear == year && x.Holiday)
            .TagWithDebugInfo("Holidays Normal")
            .ToListAsync();

        AnsiConsole.MarkupLine(ObjectDumper.Dump(currentYear).Replace("{Calendar}", "[yellow]{[/][lightskyblue3]Calendar[/][yellow]}[/]"));
    }

    /// <summary>
    /// Executes a raw SQL query to retrieve holidays for a specific year.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="year">The year to retrieve holidays for.</param>
    /// <remarks>
    /// Parameter for year is protected from SQL injection.
    /// </remarks>
    private static async Task TheSolution(Context context, int year)
    {

        var currentYear = await context.Database
            .SqlQuery<Holiday>(SqlStatements.GetHolidays(year))
            .TagWithDebugInfo("Holidays Protected")
            .ToListAsync();

        AnsiConsole.MarkupLine(ObjectDumper.Dump(currentYear)
            .Replace("{Holiday}", "[yellow]{[/][lightskyblue3]Holidays[/][yellow]}[/]"));
    }
    private static async Task TheSolutionStoredProcedure(Context context, int year)
    {

        List<HolidaysByYearResult> currentYear = await context
            .Procedures.uspHolidaysByYearAsync(year);

        AnsiConsole.MarkupLine(ObjectDumper.Dump(currentYear)
            .Replace("{Holiday}", "[yellow]{[/][lightskyblue3]Holidays[/][yellow]}[/]"));
    }
    private static async Task TheSolutionStoredProcedureFormated(Context context, int year)
    {

        List<HolidaysByYearResult> currentYear = await context
            .Procedures.uspHolidaysByYearAsync(year);

        var table = CreateTable();
        foreach (var item in currentYear)
        {
            table.AddRow(
                item.CalendarDate.ToString(), 
                item.Description, 
                item.DayOfWeekName, 
                item.BusinessDay, 
                item.Weekday);
        }

        AnsiConsole.Write(table);

    }
    public static Table CreateTable()
    {
        var table = new Table()
            .AddColumn("[b]Date[/]")
            .AddColumn("[b]Description[/]")
            .AddColumn("[b]Day Of Week[/]")
            .AddColumn("[b]Business Day[/]")
            .AddColumn("[b]Week day[/]")
            .Alignment(Justify.Left)
            .BorderColor(Color.LightSlateGrey);
        return table;
    }

    /// <summary>
    /// Executes a raw SQL query to retrieve holidays for a specific year.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="year">The year to retrieve holidays for.</param>
    /// <remarks>
    /// Parameter for year is unprotected from SQL injection.
    /// DO NOT use unless this is for a personal project with one user with a local database
    /// </remarks>
    private static async Task RawExampleUnprotected(Context context, int year)
    {

        SpectreConsoleHelpers.PrintCyan();

        var currentYear = await context.Database.SqlQueryRaw<Holiday>(
            $"""
             SELECT CalendarDate,
                    CalendarDateDescription AS [Description],
                    CalendarMonth,
                    DATENAME(MONTH, DATEADD(MONTH, CalendarMonth, -1)) AS [Month],
                    CalendarDay AS [Day],
                    DayOfWeekName,
                    IIF(BusinessDay = 0, 'No', 'Yes') AS BusinessDay,
                    IIF(Weekday = 0, 'No', 'Yes') AS [Weekday]
               FROM dbo.Calendar
              WHERE CalendarYear = {year}
                AND Holiday = 1;
             """)
            .TagWithDebugInfo("Holidays Unprotected")
            .ToListAsync();

        AnsiConsole.MarkupLine(ObjectDumper.Dump(currentYear)
            .Replace("{Holiday}", "[yellow]{[/][lightskyblue3]Holidays[/][yellow]}[/]"));

    }
}