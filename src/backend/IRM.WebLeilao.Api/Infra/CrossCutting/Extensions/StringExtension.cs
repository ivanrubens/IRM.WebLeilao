using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace IRM.WebLeilao.Api.Infra.CrossCutting.Extensions
{
    public static class StringExtension
    {
        public static int? ToNullableInt(this string s)
        {
            int i;
            if (int.TryParse(s, out i)) return i;
            return null;
        }
        public static DateTime? ToNullableDate(this string s)
        {
            DateTime i;
            if (DateTime.TryParse(s, out i)) return i;
            return null;
        }
        public static char? ToNullableChar(this string s)
        {
            char i;
            if (char.TryParse(s, out i)) return i;
            return null;
        }

        public static string NullToString(this object value)
        {
            return value == null ? "" : value.ToString();
        }

        public static bool StringToBool(this string valorStringBoleano)
        {
            string[] valores = new string[] { "SIM", "Sim", "sim", "YES", "Yes", "yes", "S", "s" };
            if (valores.Contains(valorStringBoleano))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string RemoveAccents(this string input)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = input.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        public static string RemoveSpecialChars(this string input)
        {
            string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\s]";
            string replacement = "";

            Regex rgx = new Regex(pattern);
            return rgx.Replace(input, replacement);
        }

        public static string RemoveDoubleSpaces(this string input)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);

            return regex.Replace(input, " ");
        }
    }
}