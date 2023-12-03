using ConsoleHelper.Models;
using static ConsoleHelper.Classes.DirectoryOperations;
using static ConsoleHelper.Classes.GlobbingOperations;

namespace ConsoleHelper;
internal class Program
{
    private static List<string> _projectNames = new();
    static async Task Main(string[] args)
    {
        TraverseFileMatch += GlobbingTraverseFileMatch;
        await GetProjectFiles(GetSolutionInfo().FullName);
        await File.WriteAllLinesAsync("Projects.txt", _projectNames);
    }

    private static void GlobbingTraverseFileMatch(FileMatchItem sender)
    {
        _projectNames.Add(Path.GetFileNameWithoutExtension(sender.FileName));
    }
}
