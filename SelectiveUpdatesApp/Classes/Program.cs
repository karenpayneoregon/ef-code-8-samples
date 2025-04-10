using System.Runtime.CompilerServices;
using SelectiveUpdatesApp.Data;
using SelectiveUpdatesApp.Models;

// ReSharper disable once CheckNamespace
namespace SelectiveUpdatesApp
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "EF Core Code sample";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
            CleanDatabase();
        }

        /// <summary>
        /// Deletes the existing database and recreates it.
        /// </summary>
        /// <remarks>
        /// This method ensures that the database is in a clean state by first deleting it
        /// and then recreating it. It uses the <see cref="SelectiveUpdatesApp.Data.Context"/> class
        /// to perform these operations.
        /// </remarks>
        public static void CleanDatabase()
        {
            using var context = new Context();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

    }
}
