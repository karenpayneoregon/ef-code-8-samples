namespace DatabaseCheckedApp.Models;

/// <summary>
/// Represents metadata about a database table, including its schema, name, and row count.
/// </summary>
/// <remarks>
/// This class is used to store information about user-defined tables in a database.
/// It includes the schema name, table name, and the number of rows in the table.
/// </remarks>
public class TableInfo
{
    public string TableSchema { get; set; }
    public string Name { get; set; }
    public long RowCount { get; set; }
}