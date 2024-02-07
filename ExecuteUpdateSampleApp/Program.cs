using ExecuteUpdateSampleApp.Data;
using ExecuteUpdateSampleApp.Models;
using Microsoft.EntityFrameworkCore;
using static ExecuteUpdateSampleApp.Classes.SpectreConsoleHelpers;

namespace ExecuteUpdateSampleApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        Version1(2, 9999);
        Version2(2, 8888);
        ExitPrompt();
    }
    private static void Version1(int id, int value)
    {
        PrintCyan();

        using var context = new Context();
        context.UserDetails
            .Where(ud => ud.Id == id)
            .ExecuteUpdate(x => x
                .SetProperty(u => u.Pin, value));
    }
    private static void Version2(int id, int value)
    {
        UserDetail GetUser()
        {
            using var context = new Context();
            return context.UserDetails.FirstOrDefault(ud => ud.Id == id);
        }

        PrintCyan();

        using var context = new Context();

        var user = GetUser();
        user.Pin = value;
        context.Attach(user);
        var entity = context.Entry(user);
        entity.Property(ud => ud.Pin).IsModified = true;

        context.SaveChanges();
    }
}