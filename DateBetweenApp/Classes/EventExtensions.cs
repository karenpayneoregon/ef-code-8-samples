using DateBetweenApp.Models;


namespace DateBetweenApp.Classes;
public static class EventExtensions
{
    public static IQueryable<Event> IsStartDateBetween(this IQueryable<Event> sender, DateOnly startDate, DateOnly endDate)
        => sender.Where(item => startDate <= item.StartDate && item.StartDate <= endDate);
}
