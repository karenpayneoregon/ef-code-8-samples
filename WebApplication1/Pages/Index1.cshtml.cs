using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using WebApplication1.Classes;

#nullable disable
namespace WebApplication1.Pages;

public class Index1Model : PageModel
{

    public string ConfirmationMessage { get; set; } = "Do you want to delete this customer?";
    public string ConfirmationAction { get; set; } = "DeleteCustomer";
    public int ConfirmationItemId { get; set; } = 42;


    [BindProperty]
    public bool? UserResponse { get; set; }

    [BindProperty(SupportsGet = true)]
    public string LastActionName { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? LastItemId { get; set; }

    /// <summary>
    /// Handles GET requests for the page and sets the user's response to the confirmation prompt.
    /// </summary>
    /// <param name="response">
    /// The user's response to the confirmation prompt, which can be <c>true</c>, <c>false</c>, or <c>null</c>.
    /// </param>
    public void OnGet(bool? response)
    {
        UserResponse = response;
    }

    /// <summary>
    /// Handles the confirmation response for deleting a customer.
    /// </summary>
    /// <param name="answer">The user's response to the confirmation prompt, typically "true" or "false".</param>
    /// <param name="actionName">The name of the action being confirmed (e.g., "DeleteCustomer").</param>
    /// <param name="itemId">The unique identifier of the item associated with the action.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> that redirects to the current page with the user's response and action details.
    /// </returns>
    public IActionResult OnPostConfirm(string answer, string actionName, int itemId)
    {
        if (bool.TryParse(answer, out var result))
        {
            UserResponse = result;

            if (result)
            {
                if (DataOperations.RemoveCustomer(itemId))
                {
                    Log.Information("Customer {P1} deleted.", itemId);
                }
            }
            else
            {
                Log.Information("Customer {P1} not deleted.", itemId);
            }

            // Save for feedback
            LastActionName = actionName;
            LastItemId = itemId;
        }

        // Redirect using PRG pattern
        return RedirectToPage(new
        {
            response = UserResponse,
            lastActionName = LastActionName,
            lastItemId = LastItemId
        });
    }
}