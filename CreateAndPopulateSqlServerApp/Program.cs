using CreateAndPopulateSqlServerApp.Classes;


namespace CreateAndPopulateSqlServerApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            DataOperations.CreateInitialData();
            DataOperations.Read();
            AnsiConsole.MarkupLine("[yellow]Done[/]");
            Console.ReadLine();
        }
    }
}