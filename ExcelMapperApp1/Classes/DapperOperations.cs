using System.Data;
using Dapper;
using ExcelMapperApp1.Models;
using Microsoft.Data.SqlClient;

namespace ExcelMapperApp1.Classes;

internal class DapperOperations
{
    private IDbConnection _cn = new SqlConnection(ConnectionString());
    /// <summary>
    /// Delete existing records and reset the identity column
    /// </summary>
    public void Reset()
    {
        _cn.Execute($"DELETE FROM dbo.{nameof(Customers)}");
        _cn.Execute($"DBCC CHECKIDENT ({nameof(Customers)}, RESEED, 0)");
    }
}