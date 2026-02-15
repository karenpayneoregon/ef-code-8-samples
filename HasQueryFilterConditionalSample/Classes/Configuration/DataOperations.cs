using ConsoleConfigurationLibrary.Classes;

namespace HasQueryFilterConditionalSample.Classes.Configuration;
/// <summary>
/// Performs data operations.
/// </summary>
internal class DataOperations
{
    // here for demonstration purposes
    public static void GetSettings()
    {
        Console.WriteLine(AppConnections.Instance.MainConnection);
        Console.WriteLine(EntitySettings.Instance.CreateNew);
    }
}
