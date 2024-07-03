using System.Diagnostics;

namespace ExcelMapperApp1.Classes;

public static class StringExtensions
{
    /// <summary>
    /// Split text at each capital letter
    /// </summary>
    /// <param name="input">string to work on</param>
    /// <returns>
    /// <para>An empty string, if the input is null or empty.</para>
    /// <para>Same as original if nothing affected</para>
    /// <para>String split on each uppercase token</para>
    /// <para>SSMS would become S S M S</para>
    /// </returns>
    [DebuggerStepThrough]
    public static string SplitTokens(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        Span<char> result = stackalloc char[input.Length * 2];
        var resultIndex = 0;

        for (var index = 0; index < input.Length; index++)
        {
            var currentChar = input[index];

            if (index > 0 && char.IsUpper(currentChar))
            {
                result[resultIndex++] = ' ';
            }

            result[resultIndex++] = currentChar;
        }

        return result[..resultIndex].ToString();
    }


}

