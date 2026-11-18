using System.Globalization;
using HasConversion_Bool_ColorApp.Classes;
using HasConversion_Bool_ColorApp.Classes.Core;
using HasConversion_Bool_ColorApp.Data;
using HasConversion_Bool_ColorApp.Models;
using static HasConversion_Bool_ColorApp.Classes.Helpers;
using Color = System.Drawing.Color;
namespace HasConversion_Bool_ColorApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        using var context = new Context();

        // uncomment to create and populate database
        //StartFresh(context);

        var people = context.People.ToList();

        var table = CreateTable();

        foreach (var peep in people)
        {
            table.AddRow(
                peep.Id.ToString(),
                peep.FirstName,
                peep.LastName,
                peep.IsFriend.ToYesNo(), // stored as a string, reads back as bool
                peep.IsFriend.ToString(),
                $"[{peep.Color.Name}]{peep.Color.Name}[/]",
                peep.BirthDate.ToString("d", CultureInfo.InvariantCulture)
            );
        }
        AnsiConsole.Write(table);
        
        
        Console.WriteLine();
        SpectreConsoleHelpers.ExitPrompt(Justify.Center);

    }

    /// <summary>
    /// Initializes the database with a fresh set of <see cref="Person"/> entities.
    /// </summary>
    /// <param name="context">
    /// The <see cref="Context"/> instance used to interact with the database.
    /// </param>
    /// <remarks>
    /// This method clears the existing database, recreates the schema, and adds a predefined set of 
    /// <see cref="Person"/> entities with various properties, such as names, birth dates, friendship status, 
    /// and colors. Changes are saved to the database.
    /// </remarks>
    private static void StartFresh(Context context)
    {
        CleanDatabase(context);
        
        context.Add(new Person()
        {
            FirstName = "Jim",
            LastName = "Jacobe",
            IsFriend = true,
            DateTime = new DateTime(2022, 5, 5),
            BirthDate = new DateOnly(1943,2,2),
            Color = Color.Green
        });

        context.Add(new Person()
        {
            FirstName = "Bob",
            LastName = "Smith",
            BirthDate = new DateOnly(1966, 12, 5),
            IsFriend = false,
            Color = Color.Yellow
        });

        context.Add(new Person()
        {
            FirstName = "Karen",
            LastName = "Payne",
            BirthDate = new DateOnly(1956, 9, 22),
            IsFriend = true,
            Color = Color.Red
        });

        context.SaveChanges();
    }
}