
using System.Numerics;


namespace AccessEntityFramework.Classes;


    public static class StringExtensions
    {
        public static string Ellipsis(this string sender, int width, char paddingChar = '.')
        {
            return sender.PadRight(width, paddingChar);
        }
        public static string Ellipsis<T>(this T sender, int width, char paddingChar = '.') where T : INumber<T>
        {
            return sender.ToString().Ellipsis(width, paddingChar);
        }
    }