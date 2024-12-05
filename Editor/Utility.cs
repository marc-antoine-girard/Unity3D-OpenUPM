using System.Text.RegularExpressions;

namespace ShackLab.OpenUPM.Editor
{
    internal static class Utility
    {
        internal static bool IsValidPackageName(string input, out string value)
        {
            string pattern = @"\b([a-z]+\.[a-z][a-z0-9]*)(\.[a-z0-9_-]+)*";
            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                value = match.Value;
            }
            else
            {
                value = string.Empty;
            }
            return Regex.IsMatch(input.Trim(), pattern);
        }
    }
}