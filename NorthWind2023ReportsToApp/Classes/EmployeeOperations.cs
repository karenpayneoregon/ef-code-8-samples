using NorthWind2020ConsoleApp;
using NorthWind2023Library.Data;
using NorthWind2023Library.Models;
using NorthWind2023ReportsToApp.Models;
using System.Diagnostics.CodeAnalysis;
// ReSharper disable AccessToDisposedClosure

namespace NorthWind2023ReportsToApp.Classes;

public class EmployeeOperations
{

    /// <summary>
    /// Example for self-referencing table where the property <see cref="Employees.ReportsTo"/> is null
    /// this indicates the <see cref="Employees"/> is a manager.
    ///
    /// <see cref="Employees.ReportsToNavigationEmployee"/> for a manager will contain their employees.
    /// </summary>
    public static void ReportsToManager()
    {
        using var context = new Context();

        var table = CreateViewTable();
        using var ces = new ConsoleEncodingScope();
        
        AnsiConsole.Status()

            .Start("Working...", ctx =>
            {
                Thread.Sleep(500);

                ctx.Spinner(Spinner.Known.Arrow);
                ctx.SpinnerStyle(Style.Parse("cyan"));

                List<Employees> employees = [.. context.Employees];

                List<IGrouping<int?, Employees>> groupedData = employees
                    .Where(employee => employee.ReportsTo.HasValue)
                    .OrderBy(employee => employee.LastName)
                    .GroupBy(employee => employee.ReportsTo)
                    .ToList();

                List<Manager> managers = [];

                foreach (var group in groupedData)
                {

                    Manager manager = new()
                    {
                        Employee = employees.Find(employee => employee.EmployeeID == group.Key.Value)
                    };

                    foreach (Employees groupedItem in group)
                    {
                        manager.Workers.Add(groupedItem);
                    }

                    managers.Add(manager);

                }

                managers = managers.OrderBy(employee => employee.Employee.LastName).ToList();


                Console.Clear();

                var root = new Tree("~[white on blue][B]Employees[/][/]~");

                foreach (var manager in managers)
                {
                    var currentNode = root.AddNode(manager.Employee.FullName);

                    foreach (var worker in manager.Workers)
                    {
                        currentNode.AddNode(worker.FullName);
                    }
                }
                ces.Dispose();
                AnsiConsole.Write(root);


            });
    }

    private static Table CreateViewTable() =>
        new Table()
            .Border(TableBorder.Square)
            .BorderColor(Color.Grey100)
            .Alignment(Justify.Center)
            .Title("~[white on blue][B]Employees[/][/]~")
            .AddColumn(new TableColumn("[u]Manager[/]"))
            .AddColumn(new TableColumn("[u]Workers[/]"));
}