namespace HasQueryFilterConditionalSample.Classes.Core;

/// <summary>
/// Provides utility methods for working with file paths and project structures.
/// </summary>
public class Utilities
{
    /// <summary>
    /// Retrieves the name of the project by searching for a .csproj file in the specified file path's directory or its parent directories.
    /// </summary>
    /// <param name="filePath">The file path used to locate the project directory.</param>
    /// <returns>The name of the project if a .csproj file is found; otherwise, returns the name of the top-level folder or "UnknownProject" if the directory is null.</returns>
    public static string GetProjectName(string filePath)
    {
        var directory = Path.GetDirectoryName(filePath);
        if (directory == null) return "UnknownProject";

        // Look for .csproj in the current or parent directories
        while (directory != null)
        {
            var csprojFiles = Directory.GetFiles(directory, "*.csproj");
            if (csprojFiles.Length > 0)
                return Path.GetFileNameWithoutExtension(csprojFiles[0]);

            directory = Directory.GetParent(directory)?.FullName;
        }

        // Fallback: just use the top-level folder name
        return new DirectoryInfo(Path.GetDirectoryName(filePath) ?? "").Name;
    }
}
