using System.Data;
using HasQueryFilterRazorApp.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShadowProperties.Models;
#pragma warning disable CA1416

namespace HasQueryFilterRazorApp.Pages;
public class IndexModel : PageModel
{
    private readonly ShadowProperties.Data.ShadowContext _context;

    public IndexModel(ShadowProperties.Data.ShadowContext context)
    {
        _context = context;
    }

    public IList<Contact> Contacts { get; set; } = null!;

    [BindProperty]
    public int IgnoreCount { get; set; }

    [BindProperty]
    public int Identifier { get; set; }

    public async Task OnGetAsync()
    {

        ViewData["Title"] = $"Current user {Helpers.GetUserName()}";

        if (_context.Contacts != null)
        {
            Contacts = await _context.Contacts.ToListAsync();

            await GetDeletedRecordCount();
        }

    }
    
    private async Task GetDeletedRecordCount()
    {
        await using var cn = new SqlConnection(_context.Database.GetConnectionString());
        await using var cmd = new SqlCommand
        {
            Connection = cn, 
            CommandText = "SELECT COUNT(ContactId) FROM dbo.Contact1 WHERE isDeleted = @p1"
        };
        cmd.Parameters.Add("@p1", SqlDbType.Int).Value = 1;
        await cn.OpenAsync();
        IgnoreCount = (int)cmd.ExecuteScalar();
    }
}
