using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace ExcelMapperApp1;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Excel/EF Core Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
