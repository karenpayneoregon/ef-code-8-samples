using EF_Core_MaskingSample.Data;
using EF_Core_MaskingSample1.Classes;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace EF_Core_MaskingSample1.Pages;
public class IndexModel(Context context, EncryptionService encryptionService) : PageModel
{
    public void OnGet()
    {
        var person = context.Person.FirstOrDefault();
        //person.DecryptCreditCard(encryptionService);

        if (person != null) 
        {
            person.CreditCard = "1234567890123456";
            person.EncryptCreditCard(encryptionService);
            Log.Information("{@X}", person);
            person.DecryptCreditCard(encryptionService);
            Log.Information("{@X}", person);

            //context.Update(person);
            //var xxxx = context.SaveChanges();
        }
    }
}
