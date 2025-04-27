using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkChinookLoggingSample.Classes;

public static class QueryExtensions
{

    /// <summary>
    /// Adds a debug tag to the query, providing information about the calling method, file, and line number.
    /// </summary>
    /// <typeparam name="T">The type of elements in the query.</typeparam>
    /// <param name="query">The query to which the debug tag will be added.</param>
    /// <param name="message">
    /// An optional custom message to include in the debug tag. If not provided, a default message
    /// containing the method name, file name, and line number will be used.
    /// </param>
    /// <param name="memberName">
    /// The name of the calling method. This parameter is automatically populated by the compiler.
    /// </param>
    /// <param name="filePath">
    /// The file path of the calling method. This parameter is automatically populated by the compiler.
    /// </param>
    /// <param name="lineNumber">
    /// The line number in the source file at which the method is called. This parameter is automatically
    /// populated by the compiler.
    /// </param>
    /// <returns>
    /// The original query with an added debug tag for enhanced traceability during execution.
    /// </returns>
    /// <remarks>
    /// See <see cref="EntityFrameworkQueryableExtensions.TagWith{T}(IQueryable{T}, string)"/>
    /// </remarks>
    public static IQueryable<T> TagWithDebugInfo<T>(this IQueryable<T> query,
        string message = "",
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0) =>
        query.TagWith(string.IsNullOrWhiteSpace(message) ?
            $"Executing method {memberName} in {Path.GetFileName(filePath)} at line {lineNumber}" :
            $"Executing method {memberName} in {Path.GetFileName(filePath)} at line {lineNumber} message {message}");
}
