using System.Runtime.CompilerServices;
using W = ConsoleHelperLibrary.Classes.WindowUtility;


// ReSharper disable once CheckNamespace
namespace NorthWind2020ConsoleApp;

partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample - EF Core NorthWind 2020";
        W.SetConsoleWindowPosition(W.AnchorWindow.Center);
    }
}