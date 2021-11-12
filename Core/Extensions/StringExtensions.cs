using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

namespace Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="regexPattern">Regex pattern giriniz</param>
        /// <param name="replaceItem">Değiştirilecek ifadeyi giriniz</param>
        /// <returns></returns>
        public static string RegexReplace(this string str, string regexPattern, string replaceItem, RegexOptions options = RegexOptions.None)
        {
            if (str == null) return null;
            return Regex.Replace(str, regexPattern, replaceItem, options);
        }

        public static string ReplaceTurkishCharacters(this string str)
        {
            char[] turkishAlphabet = "çöğüışİÇÖĞÜŞ".ToCharArray();
            char[] desctionationAlphabet = "coguisiCOGUs".ToCharArray();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == turkishAlphabet[i])
                {
                    //str[] = desctionationAlphabet[i];
                }
            }

            return str;
        }
    }
}
