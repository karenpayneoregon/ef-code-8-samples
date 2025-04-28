using EF_Core_MaskingSample.Data;
using EF_Core_MaskingSample1.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using EF_Core_MaskingSample1.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_Core_MaskingSample1.Pages;
public class IndexModel(Context context, EncryptionService encryptionService, PersonService personService) : PageModel
{
    [BindProperty]
    public List<Person> List { get; set; } = []; 

    public void OnGet()
    {
        // only populate if the database is empty
        //Populate();

        // read the first 20 records
        ReadPeople();
    }

    public void Populate()
    {
        var list = JsonSerializer.Deserialize<List<Person>>(System.IO.File.ReadAllText("people.json"));
        if (list == null) return;
        foreach (var person in list)
        {
            person.EncryptCreditCard(encryptionService);
            context.Person.Add(person);
        }
        context.SaveChanges();
    }

    public void ReadPeople()
    {
        for (int index = 1; index < 21; index++)
        {
            var person = context.Person.FirstOrDefault(x => x.Id == index);
            if (person == null) continue;
            person.DecryptCreditCard(encryptionService);
            List.Add(person);
        }
    }
}
