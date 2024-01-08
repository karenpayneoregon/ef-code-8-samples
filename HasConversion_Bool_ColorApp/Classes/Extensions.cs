namespace HasConversion_Bool_ColorApp.Classes;

public static class Extensions
{
    public static string ToYesNo(this bool value) => value ? "Yes" : "No";
}