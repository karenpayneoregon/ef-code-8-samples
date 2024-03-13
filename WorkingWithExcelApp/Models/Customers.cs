using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
#nullable disable
namespace WorkingWithExcelApp.Models;

[Keyless, Table("Customers$")]
public class Customers
{

    public double CustomerIdentifier { get; set; }
    public double ContactTypeIdentifier { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string ContactTitle { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string CountryName { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public DateTime ModifiedDate { get; set; }

    public override string ToString() => CompanyName;

}