using System.Diagnostics;

namespace BenchmarkDotnetTools;

internal class Program
{
    
    static void Main(string[] version)
    {
        var target = Path.Combine(
            Directory.GetCurrentDirectory(), 
            "bin", "release", version[0], "BenchmarkDotNet.Artifacts", "results");
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
