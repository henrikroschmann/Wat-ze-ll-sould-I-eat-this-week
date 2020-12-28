using System;
using System.Text.RegularExpressions;

namespace WhatZeÖl.Helpers
{
    public static class ParseText
    {
        /// <summary>
        /// Extract information between > and <
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Parser(string text, string start, string stop)
        {
            int pFrom = text.IndexOf(start) + start.Length;
            int pTo = text.LastIndexOf(stop);

            String result = text.Substring(pFrom, pTo - pFrom);

            return result;
        }

        public static string SpaceIt(string text)
        {
            var _match = Regex.Replace(text, "(?<=\\d)(?=[^\\d\\s])|(?<=[^\\d\\s])(?=\\d)", " ");
            return _match;
        }
    }
}