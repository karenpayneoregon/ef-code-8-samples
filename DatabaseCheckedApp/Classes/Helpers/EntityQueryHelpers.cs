using Dapper;
using DatabaseCheckedApp.Data;
using DatabaseCheckedApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DatabaseCheckedApp.Classes.Helpers;

class EntityQueryHelpers
{
    /// <summary>
    /// Retrieves a list of tables along with their schema and row counts from the database.
    /// </summary>
    /// <remarks>
    /// This method executes a SQL query to fetch metadata about user-defined tables in the database,
    /// including their schema, name, and the number of rows. It uses Dapper for data access.
    /// </remarks>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains a list of <see cref="TableInfo"/> objects,
    /// each representing a table's schema, name, and row count.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the database connection cannot be established.
    /// </exception>
    /// <exception cref="SqlException">
    /// Thrown if there is an error executing the SQL query.
    /// </exception>
    public static async Task<List<TableInfo>> GetTableRowCountsAsync()
    {
        await using var context = new Context();
        await using var connection = context.Database.GetDbConnection();
        const string sql = """
                           SELECT 
                               TableSchema = s.name,
                               Name = t.name,
                               [RowCount] = p.rows
                           FROM sys.tables t
                           INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
                           INNER JOIN sys.indexes i ON t.object_id = i.object_id
                           INNER JOIN sys.partitions p ON i.object_id = p.object_id AND i.index_id = p.index_id
                           WHERE t.is_ms_shipped = 0
                           GROUP BY t.name, s.name, p.rows
                           ORDER BY s.name, t.name;
                           """;

        return (await connection.QueryAsync<TableInfo>(sql)).AsList();
    }
}