using BenchmarkDotNet.Running;
using BooksApp.Classes;

namespace BooksApp;

internal static partial class Program
{

    static void Main(string[] args)
    {
        _ = BenchmarkRunner.Run<BookOperations>();

        Console.ReadLine();
    }

}