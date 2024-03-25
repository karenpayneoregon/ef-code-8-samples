using Microsoft.EntityFrameworkCore;
using WorkingWithExcelApp.Models;
#nullable disable

namespace WorkingWithExcelApp.Data;

public class LocalContext : DbContext
{
    public DbSet<Customers> Customers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseJet(
            """
            Provider = Microsoft.ACE.OLEDB.12.0;
            Data Source = Customers.xlsx;
            Extended Properties = 'Excel 12.0 Xml';
            """);
}