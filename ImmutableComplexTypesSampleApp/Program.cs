
using ImmutableComplexTypesSampleApp.Classes;

namespace ImmutableComplexTypesSampleApp;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();
        await Operations.ComplexTypesDemo();
        ExitPrompt();
    }
}