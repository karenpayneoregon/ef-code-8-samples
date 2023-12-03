namespace ConsoleHelper.Classes;
internal class DirectoryOperations
{
    public static DirectoryInfo GetSolutionInfo(string path = null!)
    {
        DirectoryInfo directory = new(path ?? Directory.GetCurrentDirectory());
        while (directory is not null && directory.GetFiles("*.sln").Length == 0)
        {
            directory = directory.Parent;
        }
        return directory;
    }

    public static string SolutionName()
    {
        return Path.GetFileName(Directory
            .GetFiles(GetSolutionInfo().FullName, "*.sln")
            .FirstOrDefault()!);
    }
}
