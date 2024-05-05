using System.Diagnostics;
using ConsoleConfigurationLibrary.Classes;
using DualContextsApp.Classes;

namespace DualContextsApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await RegisterConnectionServices.Configure();
        
        var (album, artistName) = await Operations.GetAlbumStoredProcedureParameters();
        var countries = new List<int> { 4, 9 };
        var customersCountries = await Operations.GetCustomersCountriesFiltered(countries);

        Debugger.Break();


    }
}