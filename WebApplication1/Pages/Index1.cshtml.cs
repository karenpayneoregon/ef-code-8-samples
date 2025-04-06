using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

    public void OnGet(bool? response)
    {
        UserResponse = response;
    }

    public IActionResult OnPostConfirm(string answer, string actionName, int itemId)
    {
        if (bool.TryParse(answer, out var result))
        {
            UserResponse = result;

            if (result)
            {
                if (DataOperations.RemoveCustomer(itemId))
                {
                    Console.WriteLine($"Customer {itemId} deleted.");
                }
            }
            else
            {
                Console.WriteLine($"Customer {itemId} not deleted.");
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