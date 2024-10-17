using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
namespace CalendarSqlQuerySample.Classes;

public static class QueryExtensions
{
    /// <summary>
    /// Adds debug information to the query.
    /// </summary>
    /// <typeparam name="T">The type of the query.</typeparam>
    /// <param name="query">The query to tag with debug information.</param>
    /// <param name="message">The optional debug message.</param>
    /// <param name="memberName">The name of the calling member.</param>
    /// <param name="filePath">The path of the calling file.</param>
    /// <param name="lineNumber">The line number of the calling code.</param>
    /// <returns>The query with debug information.</returns>
    /// <remarks>
    /// Author Dave Callan
    /// Additions Karen Payne
    /// </remarks>
    public static IQueryable<T> TagWithDebugInfo<T>(this IQueryable<T> query,
        string message = "",
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
#if DEBUG
        var path = Path.GetFileName(filePath);
        return query.TagWith(string.IsNullOrWhiteSpace(message) ?
            $"Executing method {memberName} in {path} at line {lineNumber}" :
            $"Executing method {memberName} in {path} at line {lineNumber} message {message}");
#else
        return query;
#endif

    }
}
