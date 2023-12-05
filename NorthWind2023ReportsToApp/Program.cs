using NorthWind2023ReportsToApp.Classes;

namespace NorthWind2023ReportsToApp;

partial class Program
{
    static void Main(string[] args)
    {
        EmployeeOperations.EmployeeReportsToManager();
        //Colored.ShowMessage("Press any key to continue");
        Console.ReadLine();
    }
}