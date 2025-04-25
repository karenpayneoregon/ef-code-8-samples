using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serilog;
using UseSeedingSqlServerExample.Data;

namespace UseSeedingSqlServerExample.Pages;
public class IndexModel : PageModel
{
    private readonly Context _context;

    public IndexModel(Context context)
    {
        _context = context;
    }

    public void OnGet()
    {
        Log.Information("Car count {C}", _context.Car.Count());

        var firstCar = _context.Car.Include(x => x.Manufacturer).FirstOrDefault();
 

    }
}
