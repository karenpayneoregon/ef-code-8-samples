using SetPropertyValuesSample.Classes;
using SetPropertyValuesSample.Models;

namespace SetPropertyValuesSample;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();

        await using var context = new Context();

        if (EntitySettings.Instance.CreateNew)
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }

        Person person = context.Person.FirstOrDefault();

        person.FirstName = "Jane";
        person.LastName = "Adams";
        
        /*
         * LastName property will not be updated as the next line
         * indicates that it should not be modified even though the value
         * has changed
         */
        context.Entry(person).Property(p => p.LastName).IsModified = false;

        var saveChanges = await context.SaveChangesAsync();
        Console.WriteLine($"Saved {saveChanges}");

  
        person.LastName = "Cater";
        saveChanges = await context.SaveChangesAsync();
        Console.WriteLine($"Saved {saveChanges}");

        /*
         * Here property values are set by properties in
         * the smaller model.
         */
        int identifier = 2;
        person = new() { Id = identifier };
        PersonModel model = new() { Id = identifier, FirstName = "Greg" };

        context.Attach(person);
        context.Entry(person).CurrentValues.SetValues(model);
        saveChanges = await context.SaveChangesAsync();
        Console.WriteLine($"Saved {saveChanges}");


        ExitPrompt();
    }
}