using Microsoft.EntityFrameworkCore;
using SelectiveUpdatesApp.Data;
using SelectiveUpdatesApp.Models;

using static SelectiveUpdatesApp.Classes.SpectreConsoleHelpers;

namespace SelectiveUpdatesApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {

            // See Program.cs in class folder which creates and populates the database

            ShouldLastNameBeUpdated();
            OnlyUpdateFirstName();

            int identifier = 5;
            var dto = new PersonDto
            {
                Title = "Miss",
                FirstName = "Karen",
                LastName = "Payne",
                BirthDate = new DateTime(1956, 9, 24)
            };

            DataTransferUpdate(identifier, dto);

            ExitPrompt();

        }


        /// <summary>
        /// Determines whether the last name of a person should be updated in the database.
        /// </summary>
        /// <remarks>
        /// This method retrieves the first person from the database and checks if their last name
        /// is different from "Gallagher". If so, it conditionally updates the last name and saves
        /// the changes to the database.
        /// </remarks>
        private static void ShouldLastNameBeUpdated()
        {
            AnsiConsole.MarkupLine($"[cyan]Running[/] [yellow]{nameof(ShouldLastNameBeUpdated)}[/]");

            using Context context = new ();
            Person person = context.Person.FirstOrDefault();

            bool modifyLastName = person!.LastName != "Gallagher";

            if (person is not null)
            {
                person.FirstName = "James";
                person.LastName = "Adams";
                context.Entry(person).State = EntityState.Modified;
                context.Entry(person).Property(p => p.LastName).IsModified = modifyLastName;
                context.SaveChanges();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Updates only the first name of a specific person in the database.
        /// </summary>
        /// <remarks>
        /// This method retrieves a person by their identifier, attaches the person entity to the context,
        /// and updates their first name using the values from a <see cref="PersonModelDto"/> instance.
        /// The changes are then saved to the database.
        /// </remarks>
        private static void OnlyUpdateFirstName()
        {
            AnsiConsole.MarkupLine($"[cyan]Running[/] [yellow]{nameof(OnlyUpdateFirstName)}[/]");

            using Context context = new ();

            int identifier = 2;
            Person person = new () { Id = identifier };
            PersonModelDto model = new() { Id = identifier, FirstName = "Karen" };

            context.Attach(person);
            context.Entry(person).CurrentValues.SetValues(model);
            context.SaveChanges();

            Console.WriteLine();
        }


        /// <summary>
        /// Updates the properties of a specific person in the database using the provided data transfer object.
        /// </summary>
        /// <param name="id">The unique identifier of the person to be updated.</param>
        /// <param name="sender">
        /// An instance of <see cref="PersonDto"/> containing the updated values for the person's properties.
        /// </param>
        /// <remarks>
        /// This method retrieves a person by their identifier, attaches the person entity to the database context,
        /// and updates their properties using the values from the provided <see cref="PersonDto"/> instance.
        /// The changes are then saved to the database.
        /// </remarks>
        private static void DataTransferUpdate(int id, PersonDto sender)
        {
            AnsiConsole.MarkupLine($"[cyan]Running[/] [yellow]{nameof(DataTransferUpdate)}[/]");

            using Context context = new();
            
            Person person = new() { Id = id };

            context.Attach(person);
            context.Entry(person).CurrentValues.SetValues(sender);

            context.SaveChanges();


        }
    }
}