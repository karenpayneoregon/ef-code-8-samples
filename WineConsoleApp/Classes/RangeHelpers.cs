using WineConsoleApp.Models;

namespace WineConsoleApp.Classes;

public class RangeHelpers
{
    public static List<Container<T>> Get<T>(List<T> sender) =>
        sender.Select((element, index) => new Container<T>
        {
            Value = element,
            StartIndex = new Index(index),
            EndIndex = new Index(sender.Count - index - 1, true),
            MonthIndex = index + 1
        }).ToList();
}