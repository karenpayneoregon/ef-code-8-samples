using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using WebApplication1.Classes;

namespace WebApplication1.Pages;

public class Index2Model : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int OrderId { get; set; } = 123; // Example ID

    public string ConfirmationMessage { get; set; } = "Are you sure you want to archive this order?";
    public string ConfirmationAction { get; set; } = "ArchiveOrder";

    [BindProperty]
    public bool? UserResponse { get; set; }

    /// <summary>
    /// Handles GET requests for the page and processes the user's response.
    /// </summary>
    /// <param name="response">
    /// The user's response as a nullable boolean, indicating their decision.
    /// </param>
    public void OnGet(bool? response)
    {
        UserResponse = response;
    }

    /// <summary>
    /// Handles the confirmation of a user action, in this case archiving an order.
    /// </summary>
    /// <param name="answer">The user's response as a string, indicating confirmation or rejection.</param>
    /// <param name="actionName">The name of the action to be performed, e.g., "ArchiveOrder".</param>
    /// <param name="itemId">The unique identifier of the item associated with the action.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> that redirects to the same page with updated parameters, 
    /// including the user's response and the item identifier.
    /// </returns>
    public IActionResult OnPostConfirm(string answer, string actionName, int itemId)
    {
        if (bool.TryParse(answer, out var result))
        {
            UserResponse = result;

            if (result && actionName == "ArchiveOrder")
            {
                DataOperations.ArchiveOrder(itemId);
            }
            else
            {
                Log.Information("Order {P1} not archived.", itemId);
            }
        }

        return RedirectToPage(new
        {
            response = UserResponse,
            orderId = itemId
        });
    }

}