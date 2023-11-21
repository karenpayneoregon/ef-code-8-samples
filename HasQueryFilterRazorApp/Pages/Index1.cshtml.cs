using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShadowProperties.Data;
using ShadowProperties.Models;

namespace HasQueryFilterRazorApp.Pages
{
    public class Index1Model : PageModel
    {
        private readonly ShadowContext _context;

        public Index1Model(ShadowContext context)
        {
            _context = context;


        }

        public void OnGet()
        {
        }

        /// <summary>
        /// DBCC CHECKIDENT ('[EF.ShadowEntityCore].[dbo].[Contact1]', reseed, 10)
        /// </summary>
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Contacts.Add(new Contact()
            {
                FirstName = "Jane",
                LastName = "Oxford",
                isDeleted = false
            });

            await _context.SaveChangesAsync();
            return await Task.FromResult<IActionResult>(Page());
        }
    }
}
