
namespace HasConversion_Bool_ColorApp.Classes.Core
{
    public static class DirectoryHelper
    {
        /// <summary>
        /// Retrieves the parent folder of the specified folder at a given level.
        /// </summary>
        /// <param name="folderName">The full path of the folder whose parent folder is to be retrieved.</param>
        /// <param name="level">
        /// The level of the parent folder to retrieve. 
        /// For example, 1 retrieves the immediate parent folder, 2 retrieves the grandparent folder, and so on.
        /// </param>
        /// <returns>
        /// The full path of the parent folder at the specified level, or <c>null</c> if the folder does not exist or the level exceeds the folder hierarchy.
        /// </returns>
        public static string? UpperFolder(this string? folderName, int level)
        {
            var folderList = new List<string>();

            while (!string.IsNullOrWhiteSpace(folderName))
            {
                var parentFolder = Directory.GetParent(folderName);
                if (parentFolder == null)
                {
                    break;
                }

                folderName = Directory.GetParent(folderName)?.FullName;
                if (!string.IsNullOrWhiteSpace(folderName))
                {
                    folderList.Add(folderName);
                }
            }

            return folderList.Count > 0 && level > 0
                ? level - 1 <= folderList.Count - 1 ? folderList[level - 1] : folderName
                : folderName;
        }

        public static string? ProjectFolder()
            => AppDomain.CurrentDomain.BaseDirectory.UpperFolder(4);

        public static string? ProjectName()
        {
            var projectFolder = ProjectFolder();
            return string.IsNullOrWhiteSpace(projectFolder) ?
                null :
                Directory.GetFiles(projectFolder, "*.csproj").FirstOrDefault();
        }

        /// <summary>
        /// From project folder, get the solution folder path
        /// </summary>
        /// <returns>folder name</returns>
        public static string SolutionFolder()
            => AppDomain.CurrentDomain.BaseDirectory.UpperFolder(5)!;
    }
}