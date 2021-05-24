using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Assesment2_BL;

namespace TitleCaseWords
{
    internal class Program
    {
        

        private static void Main(string[] args)
        {
            Console.WriteLine("Enter a sentence ");
            string sentence = Console.ReadLine();
            Console.WriteLine();
            String result = TitleCase.GetConvertedString(sentence);
            Console.WriteLine("--------------Converted String -------------------");
            Console.WriteLine();
            Console.WriteLine(result);
        }
        
        
    }
}