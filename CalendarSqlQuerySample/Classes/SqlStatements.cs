namespace CalendarSqlQuerySample.Classes;
internal class SqlStatements
{

    /// <summary>
    /// Retrieves holidays for a given year.
    /// </summary>
    /// <param name="year">The year for which to retrieve holidays.</param>
    /// <returns>A <see cref="FormattableString"/> representing the SQL query to retrieve holidays.</returns>
    /// <remarks>
    /// Uses IIF vs CASE
    /// </remarks>
    public static FormattableString GetHolidays(int year) => 
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
           AND Holiday      = 1;
         """;

    /// <summary>
    /// Retrieves holidays for a given year.
    /// </summary>
    /// <param name="year">The year for which to retrieve holidays.</param>
    /// <returns>A <see cref="FormattableString"/> representing the SQL query to retrieve holidays for EF Core.</returns>
    /// <remarks>
    /// Uses CASE vs IIF
    /// </remarks>
    public static FormattableString GetHolidays1(int year) =>
        $"""
         SELECT CalendarDate,
             CalendarDateDescription AS [Description],
             CalendarMonth,
             DATENAME(MONTH, DATEADD(MONTH, CalendarMonth, -1)) AS [Month],
             CalendarDay AS [Day],
             DayOfWeekName,
             CASE WHEN BusinessDay = 0 THEN 'No' ELSE 'Yes' END AS BusinessDay,
             CASE WHEN Weekday = 0 THEN 'No' ELSE 'Yes' END AS [Weekday]
         FROM dbo.Calendar
         WHERE CalendarYear = {year}
           AND Holiday      = 1;
         """;
}
