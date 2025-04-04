using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public bool? UserResponse { get; set; }

    public void OnGet(bool? response)
    {
        UserResponse = response;
    }

    public IActionResult OnPostConfirm(string answer)
    {
        if (bool.TryParse(answer, out var result))
        {
            UserResponse = result;
        }

        // PRG pattern to avoid form resubmission on refresh
        return RedirectToPage(new { response = UserResponse });
    }
}

