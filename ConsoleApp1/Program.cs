using System.Globalization;
using System.Text;
namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {

        List<string> items = [.. DateTimeFormatInfo.CurrentInfo.MonthNames[..^1]];

        Console.WriteLine(string.Join(",", items));
        Console.WriteLine(items.Aggregate((left, right) => $"{left},{right}"));
        Console.ReadLine();
    }

}

public static class Extensions
{
    public static string Aggregate(this IEnumerable<string> source, Func<string, string, string> fn)
    {
        StringBuilder sb = new();
        foreach (string s in source)
        {
            if (sb.Length > 0) sb.Append(",");
            sb.Append(s);
        }

        return sb.ToString();
    }
}
