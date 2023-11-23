using WineConsoleApp.Models;

namespace WineConsoleApp.Classes;

public class RangeHelpers
{

    public static List<Container<T>> Get<T>(List<T> list) =>
        list.Select((element, index) => new Container<T>
        {
            Value = element,
            StartIndex = new Index(index),
            EndIndex = new Index(Enumerable.Range(0, list.Count).Reverse().ToList()[index],
                true),
            MonthIndex = index + 1
        }).ToList();
}