using System.Diagnostics;

namespace BenchmarkDotnetTools;

internal class Program
{
    /// <summary>
    /// Open the results folder of the selected project in Visual Studio for BenchmarkDotNet
    /// </summary>
    /// <param name="version">version of dotnet e.g.  net8.0</param>
    /// <remarks>
    /// Project type is Windows Forms so the console window does not show.
    /// </remarks>
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
