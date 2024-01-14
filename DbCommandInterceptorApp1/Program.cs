using DbCommandInterceptorApp1.Classes;
using static DbCommandInterceptorApp1.Classes.SpectreConsoleHelpers;

namespace DbCommandInterceptorApp1;

internal partial class Program
{
    static void Main(string[] args)
    {
        CommandSourceSample.GetCommandSource();
        ExitPrompt();
    }
}