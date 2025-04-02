using Dapper;
using DatabaseCheckedApp.Data;
using DatabaseCheckedApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Extensions.Configuration;

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
        const string sql =
            """
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

    /// <summary>
    /// Retrieves the row counts for specified database tables.
    /// </summary>
    /// <param name="tableNames">
    /// An array of table names for which to retrieve row counts. 
    /// If no table names are provided, row counts for all user-defined tables are returned.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains a list of 
    /// <see cref="TableInfo"/> objects, each representing metadata about a table, including its schema, 
    /// name, and row count.
    /// </returns>
    /// <remarks>
    /// This method queries the database using Dapper to retrieve row count information for the specified tables.
    /// It connects to the database using the connection string defined in the application's configuration.
    /// </remarks>
    /// <exception cref="SqlException">
    /// Thrown if there is an issue connecting to the database or executing the query.
    /// </exception>
    /// <example>
    /// <code>
    /// var tableInfos = await EntityQueryHelpers.GetTableRowCountsAsync("Customer", "Orders");
    /// foreach (var tableInfo in tableInfos)
    /// {
    ///     Console.WriteLine($"{tableInfo.TableSchema}.{tableInfo.Name}: {tableInfo.RowCount} rows");
    /// }
    /// </code>
    /// </example>
    public static async Task<List<TableInfo>> GetTableRowCountsAsync(params string[] tableNames)
    {

        /*
         * Config is defined in GlobalUsings.cs
         * ConnectionStrings is defined in ConsoleConfigurationLibrary
         */
        var connectionString = Config.Configuration.JsonRoot()
            .GetSection(nameof(ConnectionStrings))
            .GetValue<string>(nameof(ConnectionStrings.MainConnection));

        IDbConnection cn = new SqlConnection(connectionString);

        const string sql =
            """
            SELECT 
                TableSchema = s.name,
                Name = t.name,
                [RowCount] = p.rows
            FROM sys.tables t
            INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
            INNER JOIN sys.indexes i ON t.object_id = i.object_id
            INNER JOIN sys.partitions p ON i.object_id = p.object_id AND i.index_id = p.index_id
            WHERE t.is_ms_shipped = 0
            AND t.name IN @TableNames
            GROUP BY t.name, s.name, p.rows
            ORDER BY s.name, t.name;
            """;

        return (await cn.QueryAsync<TableInfo>(sql, new { TableNames = tableNames })).ToList();
    }

}

