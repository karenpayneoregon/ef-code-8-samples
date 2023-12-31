﻿
using ImmutableComplexTypesSampleApp.Classes;
using static UtilityLibarary.SpectreConsoleHelpers;

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