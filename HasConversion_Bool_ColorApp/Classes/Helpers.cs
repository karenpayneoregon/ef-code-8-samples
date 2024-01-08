using Microsoft.EntityFrameworkCore;

namespace HasConversion_Bool_ColorApp.Classes;

public class Helpers
{
    /// <summary>
    /// Recreate or create database and schema
    /// </summary>
    /// <param name="context"></param>
    public static void CleanDatabase(DbContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
}