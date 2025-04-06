using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

    public void OnGet(bool? response)
    {
        UserResponse = response;
    }

    public IActionResult OnPostConfirm(string answer, string actionName, int itemId)
    {
        if (bool.TryParse(answer, out var result))
        {
            UserResponse = result;

            if (actionName == "ArchiveOrder" && result)
            {
                Console.WriteLine($"Order {itemId} archived.");
                // Insert actual archive logic here
            }
        }

        return RedirectToPage(new
        {
            response = UserResponse,
            orderId = itemId
        });
    }
}