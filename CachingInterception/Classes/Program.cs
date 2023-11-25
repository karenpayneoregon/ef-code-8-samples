using System;
using System.Runtime.CompilerServices;
using ConsoleHelperLibrary.Classes;

// ReSharper disable once CheckNamespace
namespace CachingInterception;

public static partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Fill);
    }

}
