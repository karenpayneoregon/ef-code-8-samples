namespace CalendarSqlQuerySample.Models;
/// <summary>
/// Represents a holiday with various attributes such as date, description, month, day, and business day status.
/// </summary>
/// <remarks>
/// This model is the same as <see cref="HolidaysByYearResult"/> where both models could be
/// merged into one but are kept separate for demonstration purposes.
/// </remarks>
internal class Holiday
{
    public DateOnly CalendarDate { get; set; }
    public string Description { get; set; }
    public int CalendarMonth { get; set; }
    public string Month { get; set; }
    public int Day { get; set; }
    public string DayOfWeekName { get; set; }
    public string BusinessDay { get; set; }
    public string Weekday { get; set; }
}
