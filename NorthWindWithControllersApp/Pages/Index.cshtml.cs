using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace NorthWindWithControllersApp.Pages;
public class IndexModel : PageModel
{
    public void OnGet()
    {
        Log.Information("Greetings");
    }
}
