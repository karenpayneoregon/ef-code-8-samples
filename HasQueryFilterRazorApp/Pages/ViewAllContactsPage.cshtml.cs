using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShadowProperties.Data;
using ShadowProperties.Models;

namespace HasQueryFilterRazorApp.Pages;

/// <summary>
/// Provide the ability to delete or un-delete, think of this as a admin screen
/// without prompting are you sure.
/// </summary>
public class ViewAllContactsPageModel : PageModel
{
    private readonly ShadowContext _context;

    public ViewAllContactsPageModel(ShadowContext context)
    {
        _context = context;
    }

    [BindProperty]
    public IList<Contact> Contacts { get;set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Contacts != null)
        {
            Contacts = await _context
                .Contacts
                .IgnoreQueryFilters() // IMPORTANT
                .ToListAsync();

            var test = _context
                .Contacts
                .IgnoreQueryFilters() // IMPORTANT
                ;
        }
    }

    public async Task<RedirectToPageResult> OnPost()
    {

        for (int index = 0; index < Contacts.Count; index++)
        {

            var current = Contacts[index];
            var contact = await _context
                .Contacts
                .IgnoreQueryFilters() // IMPORTANT
                .FirstOrDefaultAsync(x => x.ContactId == Contacts[index].ContactId);

            if (contact is not null)
            {
                contact.isDeleted = current.isDeleted;
            }

        }

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}