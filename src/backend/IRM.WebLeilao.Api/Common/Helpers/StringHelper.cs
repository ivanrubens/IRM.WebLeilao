using System.Text.RegularExpressions;

namespace IRM.WebLeilao.Api.Common.Helpers
{
    public class StringHelper
    {
        public static bool HaCaracteresInvalidos(string input)
        {
            string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç'\s]";

            Regex rgx = new Regex(pattern);
            return rgx.IsMatch(input);
        }
    }
}