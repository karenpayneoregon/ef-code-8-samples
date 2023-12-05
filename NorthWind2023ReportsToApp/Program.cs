using NorthWind2023ReportsToApp.Classes;
using static UtilityLibarary.SpectreConsoleHelpers;
namespace NorthWind2023ReportsToApp;

partial class Program
{
    static void Main(string[] args)
    {
        EmployeeOperations.EmployeeReportsToManager();
        ExitPrompt();
    }
}