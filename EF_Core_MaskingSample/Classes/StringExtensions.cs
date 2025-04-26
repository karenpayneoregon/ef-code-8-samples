namespace EF_Core_MaskingSample.Classes;
internal static class StringExtensions
{
    /// <summary>
    /// Masks and colorizes a Social Security Number (SSN) for display purposes.
    /// </summary>
    /// <param name="ssn">
    /// The original Social Security Number (SSN) to be masked and colorized.
    /// </param>
    /// <returns>
    /// A string representation of the SSN with the first five digits masked and the last four digits
    /// displayed, formatted with color tags.
    /// </returns>
    public static string Colorized1(this string ssn) => $"[{Color.Pink1}]XXX-XX-[/]{ssn[^4..]}";
    public static string Colorized2(this string cc) => $"[{Color.Pink1}]****-****-****-[/]{cc[^4..]}";
}
