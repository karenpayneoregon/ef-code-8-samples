using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShadowProperties.Models;

namespace HasQueryFilterRazorApp.Pages;

public class DeleteContactPageModel : PageModel
{
    private readonly ShadowProperties.Data.ShadowContext _context;

    public DeleteContactPageModel(ShadowProperties.Data.ShadowContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Contact Contact { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Contacts == null)
        {
            return NotFound();
        }

        var contact = await _context.Contacts.FirstOrDefaultAsync(m => m.ContactId == id);

        if (contact == null)
        {
            return NotFound();
        }
        else 
        {
            Contact = contact;
        }

        return Page();

    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null || _context.Contacts == null)
        {
            return NotFound();
        }
        var contact = await _context.Contacts.FindAsync(id);

        if (contact != null)
        {
            Contact = contact;
            _context.Contacts.Remove(Contact);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}