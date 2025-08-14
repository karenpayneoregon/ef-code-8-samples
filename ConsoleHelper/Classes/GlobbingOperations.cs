using ConsoleHelper.Models;
using Microsoft.Extensions.FileSystemGlobbing;

namespace ConsoleHelper.Classes;
internal class GlobbingOperations
{
    public delegate void OnTraverseFileMatch(FileMatchItem sender);
    public static event OnTraverseFileMatch? TraverseFileMatch;

    public static async Task GetProjectFiles(string parentFolder)
    {

        Matcher matcher = new();
        matcher.AddIncludePatterns(["**/*.csproj"]);

        await Task.Run(() =>
        {
            foreach (string file in matcher.GetResultsInFullPath(parentFolder))
            {
                TraverseFileMatch?.Invoke(new FileMatchItem(file));
            }
        });
    }

}