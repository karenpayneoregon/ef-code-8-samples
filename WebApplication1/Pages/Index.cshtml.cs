using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public bool? UserResponse { get; set; }

    /// <summary>
    /// Handles the GET request for the page and initializes the user's response.
    /// </summary>
    /// <param name="response">The user's response passed as a nullable boolean query parameter.</param>
    public void OnGet(bool? response)
    {
        UserResponse = response;
    }

    /// <summary>
    /// Handles the POST request for confirming the user's response.
    /// </summary>
    /// <param name="answer">The user's response as a string, which will be parsed into a boolean value.</param>
    /// <returns>An <see cref="IActionResult"/> that redirects to the same page with the user's response as a query parameter.</returns>
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

