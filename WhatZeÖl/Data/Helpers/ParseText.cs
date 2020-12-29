using System;
using System.Text.RegularExpressions;

namespace WhatZeÖl.Helpers
{
    public static class ParseText
    {
        /// <summary>
        /// Method is used to extract parts of string based on start and stop condiction
        /// these are input paraters.
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

        /// <summary>
        /// When extracting the instructions from the recipie space is missing between step and text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string SpaceIt(string text)
        {
            var _match = Regex.Replace(text, "(?<=\\d)(?=[^\\d\\s])|(?<=[^\\d\\s])(?=\\d)", " ");
            return _match;
        }
    }
}