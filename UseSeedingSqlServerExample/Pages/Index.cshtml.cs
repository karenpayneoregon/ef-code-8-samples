using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serilog;
using UseSeedingSqlServerExample.Data;
using UseSeedingSqlServerExample.Models;

namespace UseSeedingSqlServerExample.Pages;
public class IndexModel(Context context) : PageModel
{
    private readonly Context _context = context;

    [BindProperty]
    public required List<Car> Cars { get; set; }

    //public void OnGet()
    //{
    //    Log.Information("Car count {C}", _context.Car.Count());

    //    var firstCar = _context.Car.Include(x => x.Manufacturer).FirstOrDefault();
    //}

    public async Task OnGetAsync()
    {
        Cars = await _context.Car.Include(c => c.Manufacturer).ToListAsync();
    }
}
