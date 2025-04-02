using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serilog;
using UseSeedingSqlServerExample.Data;

namespace UseSeedingSqlServerExample.Pages;
public class IndexModel : PageModel
{
    private readonly CarDbContext _context;

    public IndexModel(CarDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        Log.Information("Greetings");
    }
}
