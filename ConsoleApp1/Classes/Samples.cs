using System.Globalization;

namespace ConsoleApp1.Classes;
internal class Samples
{
    public static void JoinSamples()
    {
        List<string> items = [.. DateTimeFormatInfo.CurrentInfo.MonthNames[..^1]];

        Console.WriteLine(string.Join(",", items));
        Console.WriteLine(items.Aggregate((left, right) => $"{left},{right}"));
    }
}
