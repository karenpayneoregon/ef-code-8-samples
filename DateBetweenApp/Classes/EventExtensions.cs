using DateBetweenApp.Models;


namespace DateBetweenApp.Classes;
public static class EventExtensions
{
    ///// <summary>
    ///// Filters the events to include only those whose start date falls between the specified start and end dates.
    ///// </summary>
    ///// <param name="sender">The queryable collection of events.</param>
    ///// <param name="startDate">The start date to filter from.</param>
    ///// <param name="endDate">The end date to filter to.</param>
    ///// <returns>A queryable collection of events with start dates between the specified start and end dates.</returns>
    //public static IQueryable<Event> IsStartDateBetween(this IQueryable<Event> sender, DateOnly startDate, DateOnly endDate)
    //    => sender.Where(item => startDate <= item.StartDate && item.StartDate <= endDate);

    /// <summary>
    /// Filters the events to include only those whose start date falls between the specified start and end dates.
    /// </summary>
    /// <param name="sender">The queryable collection of events.</param>
    /// <param name="startDate">The start date to filter from.</param>
    /// <param name="endDate">The end date to filter to.</param>
    /// <returns>A queryable collection of events with start dates between the specified start and end dates.</returns>
    public static IQueryable<IBaseEvent>IsStartDateBetween(this IQueryable<IBaseEvent> sender, DateOnly startDate, DateOnly endDate)
        => sender.Where(item => startDate <= item.StartDate && item.StartDate <= endDate);
}

