using System.Text.RegularExpressions;

namespace Insurance.Common.Helper
{
    public class StringHelper
    {
        public static string RemoveCharacters(string text, string regex)
        {
            Regex reg = new Regex(regex);
            return reg.Replace(text, string.Empty);
        }

        public static string CleanCpf(string cpf)
        {
            return RemoveCharacters(cpf, @"[^0-9]");
        }
    }
}
