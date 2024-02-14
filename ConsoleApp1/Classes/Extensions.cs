using System.Text;

namespace ConsoleApp1.Classes;

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