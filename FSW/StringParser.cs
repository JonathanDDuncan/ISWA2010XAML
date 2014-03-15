using System.Text.RegularExpressions;

namespace FSW
{
    static class StringParser
    {

        public static string GetSequenceBuildStr(this string str)
        {
            return Regex.Match(str, "A[^>MLR]*").Value;
        }

        public static string GetSymbolsBuildStr(this string str)
        {
            string left = Regex.Match(str, "[MLR].*$").Value;
            return left == string.Empty ? GetPunctuation(str) : left;
        }

        private static string GetPunctuation(string str)
        {
            var match = Regex.Match(str, "S38[7-9ab][0-5][0-9a-f][0-9]{3}x[0-9]{3}");
            return match.Success ? match.Value : string.Empty;
        }
    }
}
