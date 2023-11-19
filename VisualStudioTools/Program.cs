using System.Diagnostics;

namespace VisualStudioTools;

internal class Program
{
    static void Main(string[] paths)
    {
        var target = Path.Combine(
            Directory.GetCurrentDirectory(), 
            "bin", "release", "net8.0", "BenchmarkDotNet.Artifacts", "results");
        if (Directory.Exists(target))
        {
            Process.Start("explorer.exe", $"/select, {target}");
        }
        else
        {
            Console.WriteLine($"Not found");
            Console.WriteLine(target);
            Console.ReadLine();
        }
    }
}
