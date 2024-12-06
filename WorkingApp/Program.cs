
namespace WorkingApp;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();

        ProcessAndDisplayVersions();
        Console.WriteLine();
        SortAndPrintVersions();
        Console.WriteLine();
        SortAndDisplayVersions();

        ExitPrompt();
    }

    private static void ProcessAndDisplayVersions()
    {
        List<string> ver = ["3.5", "3.15", "3.10", "3.1"];
        var orderData = new List<Version>();

        foreach (var version in ver)
        {
            orderData.Add(new Version(version));
        }

        // Sort the list in descending order
        orderData.Sort((x, y) => y.CompareTo(x));

        foreach (var version in orderData)
        {
            Console.WriteLine(version);
        }
    }

    private static void SortAndPrintVersions()
    {
        List<string> ver = ["3.5", "3.15", "3.10", "3.1"];
        List<Version> orderData = ver.Select(x => new Version(x))
            .OrderByDescending(x => x)
            .ToList();

        foreach (var version in orderData)
        {
            Console.WriteLine(version);
        }
    }

    private static void SortAndDisplayVersions()
    {
        List<Version> versions =
        [
            new(3, 5, 0),
            new(3, 15, 0),
            new(3, 10, 0),
            new(3, 1, 0)
        ];

        versions = versions.OrderByDescending(x => x).ToList();
        foreach (var version in versions)
        {
            Console.WriteLine(version);
        }
    }
}