using Microsoft.EntityFrameworkCore;
using UserDefineFunctionMapping1.Data;
using UserDefineFunctionMapping1.Models;


namespace UserDefineFunctionMapping1;

internal partial class Program
{
    static void Main(string[] args)
    {

        using var context = new Context();
        const string excludeThisContact = "Patricio Simpson";
        List<Contacts> list = context
            .Contacts
            .Include(c => c.ContactTypeIdentifierNavigation)
            .Where(c => context.ConcatStrings(c.FirstName, c.LastName) != excludeThisContact)
            .ToList();

    }
}