using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NorthWind2024StarterApp.Data;
using NorthWind2024StarterApp.Models;

namespace NorthWind2024StarterApp;
public partial class RawSqlForm : Form
{

    //https://www.learnentityframeworkcore.com/raw-sql/from-sql
    public RawSqlForm()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {


        var statement =
            """
            SELECT *
             FROM dbo.Customers
            WHERE ContactTypeIdentifier = 9
            """;
        using var context = new Context();
        var list = context.Customers.FromSqlRaw(statement)
            .Include(c => c.Contact)
            .ToList();

        Debugger.Break();

    }

    private void button2_Click(object sender, EventArgs e)
    {

        var param = new SqlParameter("@ContactTypeIdentifier", 9);

        string statement =
            """
            SELECT CustomerIdentifier
            ,CompanyName
            ,ContactId
            ,Street
            ,City
            ,Region
            ,PostalCode
            ,CountryIdentifier
            ,Phone
            ,Fax
            ,ContactTypeIdentifier
            ,ModifiedDate
            FROM dbo.Customers
            WHERE ContactTypeIdentifier = @ContactTypeIdentifier
            """;
        using var context = new Context();
        var list = context.Customers.FromSqlRaw(statement, param)
            .Include(c => c.Contact)
            .ToList();

        Debugger.Break();
    }

    private void FormattableString_Click(object sender, EventArgs e)
    {

        const int contactTypeIdentifier = 9;
        FormattableString statement =
            $"""
             SELECT *
              FROM dbo.Customers
             WHERE ContactTypeIdentifier = {contactTypeIdentifier}
             """;

        using var context = new Context();
        var list = context.Customers.FromSqlInterpolated(statement)
            .Include(c => c.Contact)
            .ToList();

    }

    private void button4_Click(object sender, EventArgs e)
    {
        List<int> countries = [4, 9];
        //using var context = new Context();
        //var test = string.Join(", ", countries);




        //IQueryable<CustomersCountries> data = context.Database
        //    .SqlQuery<CustomersCountries>($"""
        //                                   SELECT Cust.CustomerIdentifier,
        //                                          Cust.CompanyName,
        //                                          Cust.CountryIdentifier,
        //                                          CO.[Name] AS CountryName
        //                                   FROM dbo.Customers AS Cust
        //                                       INNER JOIN dbo.Countries AS CO
        //                                           ON Cust.CountryIdentifier = CO.CountryIdentifier
        //                                   WHERE Cust.CountryIdentifier IN ({test})
        //                                   """);


        //var list = data.OrderBy(x => x.CountryName).ToList();

        var list = GetCustomersCountriesFiltered(countries);

        Debugger.Break();
    }

    /// <summary>
    /// Retrieves a filtered list of customers and their associated countries based on the specified country identifiers.
    /// </summary>
    /// <param name="countries">
    /// A list of country identifiers used to filter the customers.
    /// </param>
    /// <returns>
    /// A list of <see cref="CustomersCountries"/> objects containing customer and country details
    /// for the specified country identifiers.
    /// </returns>
    /// <remarks>
    /// This method executes a raw SQL query to fetch customer and country data from the database.
    /// The query filters customers based on the provided country identifiers.
    /// </remarks>
    public static List<CustomersCountries> GetCustomersCountriesFiltered(List<int> countries)
    {
        
        using var context = new Context();
        
        FormattableString sql = 
            $"""
             SELECT Cust.CustomerIdentifier,
                    Cust.CompanyName,
                    Cust.CountryIdentifier,
                    CO.[Name] AS CountryName
             FROM dbo.Customers AS Cust
                 INNER JOIN dbo.Countries AS CO
                     ON Cust.CountryIdentifier = CO.CountryIdentifier
             """;

        
        IQueryable<CustomersCountries> data = context.Database
            .SqlQuery<CustomersCountries>(sql)
            .Where(x => countries.Contains(x.CountryIdentifier));

        return data.ToList();
    }
    
    
}
