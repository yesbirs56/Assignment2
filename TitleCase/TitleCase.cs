using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TitleCase
{
    internal class TitleCase
    {
        //List contains all the word which are to be ignored
        private static readonly List<string> ignoreWords = new List<string>()
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

        private static void Main(string[] args)
        {
            Console.WriteLine("Enter a sentence ");
            string sentence = Console.ReadLine();
            Console.WriteLine();
            String result = ConvertString(sentence);
            Console.WriteLine("----------------------------------------Converted String --------------------------------------");
            Console.WriteLine();
            Console.WriteLine(result);
        }

        // Convert The Sentence into Title Case and return converted string
        private static string ConvertString(string sentence)
        {
            // Split the sentence by spaces and gives array of words string
            string[] words = sentence.Split(" ");
            // StringBuilder is used because there is lot of string concatinations
            //var query = words.Where(word=>)
            StringBuilder result = new StringBuilder("");
            foreach (string word in words)
            {
                if (!ignoreWords.Contains(word))
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