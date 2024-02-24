namespace EntityFrameworkChinookLoggingSample.Classes;
public static class Extensions
{
    public static string ShowTime(this int sender)
        => TimeSpan.FromMilliseconds(sender).ToString(@"mm\:ss");
}
