using BogusProperGenderEntityLib.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace BogusProperGenderEntityWeb.Pages;
public class IndexModel : PageModel
{
    private readonly Context _context;

    public IndexModel(Context context)
    {
        _context = context;
    }

    /// <summary>
    /// Proof we read the data
    /// </summary>
    public void OnGet()
    {
        var list = _context.BirthDays.ToList();
        Log.Information("{@Item}", list);
    }
}
