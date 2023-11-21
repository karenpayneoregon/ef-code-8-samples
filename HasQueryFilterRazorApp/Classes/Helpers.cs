#pragma warning disable CA1416
#pragma warning disable CA1416
namespace HasQueryFilterRazorApp.Classes;

public class Helpers
{
    public static string GetUserName()
    {
        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        if (userName.Contains("\\"))
        {
            string[] parts = userName.Split('\\');
            userName = parts[1];
        }
        return userName;
    }
}
