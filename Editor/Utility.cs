using System;

namespace ShackLab.OpenUPM.Editor
{
    internal static class Utility
    {
        internal static string NormalizeCommand(string input)
        {
            input = input.Trim();
            input = input.StartsWith("openupm add", StringComparison.OrdinalIgnoreCase)
                ? input.Substring("openupm add".Length).Trim()
                : input;
            
            input = input.Trim('"');
            return input;
        }
    }
}