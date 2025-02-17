using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
namespace CalendarSqlQuerySample.Classes.DatabaseClasses;

/// <summary>
/// Provides extension methods for enhancing and debugging Entity Framework Core queries.
/// </summary>
public static class QueryExtensions
{
    /// <summary>
    /// Tags the provided query with debug information, including the calling member name,
    /// file path, and line number, to assist in debugging during development.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the query.</typeparam>
    /// <param name="query">The query to be tagged with debug information.</param>
    /// <param name="message">An optional debug message to include in the tag.</param>
    /// <param name="memberName">The name of the calling member. Automatically provided by the compiler.</param>
    /// <param name="filePath">The file path of the calling code. Automatically provided by the compiler.</param>
    /// <param name="lineNumber">The line number of the calling code. Automatically provided by the compiler.</param>
    /// <returns>The query tagged with debug information if in debug mode; otherwise, the original query.</returns>
    /// <remarks>
    /// This method is only effective in debug mode and is intended to provide additional context
    /// for debugging purposes. In release mode, the query remains unaltered.
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
