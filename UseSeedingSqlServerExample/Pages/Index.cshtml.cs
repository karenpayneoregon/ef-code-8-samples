using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UseSeedingSqlServerExample.Data;
using UseSeedingSqlServerExample.Models;

namespace UseSeedingSqlServerExample.Pages;
public class IndexModel(Context context) : PageModel
{
    [BindProperty]
    public required List<Car> Cars { get; set; }


    /// <summary>
    /// This method retrieves a list of cars from the database, including their associated manufacturers,
    /// and assigns it to the <see cref="Cars"/> property.
    /// </summary>
    public async Task OnGetAsync()
    {
        Cars = await context.Car.Include(c => c.Manufacturer).ToListAsync();
    }
}
