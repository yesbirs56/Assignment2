using System.Collections.Generic;
using System.Text;

namespace Assesment2_BL
{
    /// <summary>
    /// The static class whic contains static members to convert String into
    /// Title case except is word are conjunctions, articles, prepositions.
    /// </summary>
    public static class TitleCase
    {
        // List of words are to be ignored
        private static readonly List<string> _ignoreWords = new List<string>()
            {
                "and",
                "or",
                "but",
                "nor",
                "yet",
                "so",
                "for",
                "a",
                "an",
                "the",
                "in",
                "to",
                "of",
                "at",
                "by",
                "up",
                "for",
                "off",
                "on"
            };

        /// <summary>
        /// Convert the sentence into TitleCase
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns>converted title case string </returns>
        public static string GetConvertedString(string sentence)
        {
            sentence = sentence.Trim();

            if(sentence.Length == 0)
            {
                return "";
            }
            // Split the sentence by spaces and gives array of words string
            string[] words = sentence.Split(" ");
            // StringBuilder is used because there is lot of string concatinations
            //var query = words.Where(word=>)
            StringBuilder result = new StringBuilder("");
            foreach (string word in words)
            {
                if (!_ignoreWords.Contains(word))
                {
                    string temp = word.Substring(0, 1).ToUpper() + word[1..];
                    result.Append(temp + " ");
                }
                else
                {
                    result.Append(word + " ");
                }
            }
            return result.ToString();
        }
    }
}