namespace GetWeekendDatesCorrectlyAppCore.Models;

public class ItemContainer
{
    public DayOfWeek DayOfWeek { get; }
    public List<Order> List { get; }

    public ItemContainer(DayOfWeek dayOfWeek, List<Order> list)
    {
        DayOfWeek = dayOfWeek;
        List = list;
    }
}