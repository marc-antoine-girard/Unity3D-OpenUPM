using System;
using System.Text.RegularExpressions;

namespace ShackLab.OpenUPM.Editor
{
    internal static class Utility
    {
        internal static bool IsValidPackageName(string input)
        {
            string pattern = @"^(?=.{1,214}$)([a-z]+\.[a-z][a-z0-9]*)(\.[a-z0-9_-]+)*$";
            return Regex.IsMatch(input.Trim(), pattern);
        }
        
        internal static string NormalizeCommand(string input)
        {
            input = input.Trim();
            return input.StartsWith("openupm add", StringComparison.OrdinalIgnoreCase)
                ? input.Substring("openupm add".Length).Trim()
                : input;
        }
    }
}