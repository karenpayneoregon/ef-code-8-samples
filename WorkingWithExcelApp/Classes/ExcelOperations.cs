using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using WorkingWithExcelApp.Data;
using WorkingWithExcelApp.Models;

namespace WorkingWithExcelApp.Classes;
internal class ExcelOperations
{
    public static List<Customers> ReadSheet()
    {
        using var db = new LocalContext();

        db.Database.OpenConnection();
        var connection = db.Database.GetDbConnection();

        return db.Customers!.ToList();
    }

    public static void ShowDetails()
    {
        using var db = new LocalContext();

        db.Database.OpenConnection();
        var connection = db.Database.GetDbConnection();

        using var tables = connection.GetSchema("Tables");

        foreach (DataRow table in tables.Rows)
        {
            var tableName = (string)table["TABLE_NAME"];
            Debug.WriteLine(tableName);

            var command = connection.CreateCommand();
            command.CommandType = CommandType.TableDirect;
            command.CommandText = tableName;

            using var reader = command.ExecuteReader(CommandBehavior.SchemaOnly);

            using var columns = reader.GetSchemaTable();
            foreach (DataRow column in columns!.Rows)
            {
                Debug.WriteLine($"    {column["DataType"]} {column["ColumnName"]}");
            }


        }
    }
}
