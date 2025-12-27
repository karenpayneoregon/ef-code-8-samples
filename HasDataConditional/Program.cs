
using HasDataConditional.Classes;
using HasDataConditional.Data;
using Microsoft.EntityFrameworkCore;

namespace HasDataConditional;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();

        await FetchContactsWithDetailsAsync();
        ExitPrompt();
    }

    private static async Task FetchContactsWithDetailsAsync()
    {
        await using var context = new Context();
        var list = await context
            .Contacts
            .Include(x => x.ContactTypeIdentifierNavigation)
            .Include(x => x.ContactDevices)
            .ToListAsync();
    }

}