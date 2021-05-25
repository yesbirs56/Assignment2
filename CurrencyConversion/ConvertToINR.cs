using Assesment2_BL;
using System;
using System.Collections.Generic;
using System.IO;

namespace CurrencyConversion
{
    internal class ConvertToINR
    {
        public static void Main(string[] args)
        {
            string path = $@"{Directory.GetCurrentDirectory()}\currency.dat";

            CurrencyConverter currencyData = new CurrencyConverter(path); ;
            if (currencyData.IsDataExist())
            {
                Console.WriteLine("Do you want to Continue with existing Data Or Create New One ? (y/n)");
                char ch = 'n';
                try
                {
                    ch = Convert.ToChar(Console.ReadLine());
                }
                catch (FormatException exc)
                {
                    Console.WriteLine(exc.Message);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }

                if (ch == 'y')
                {
                    Console.WriteLine("Enter the symbol and rate of foreign currency ");
                    Dictionary<string, double> data = TakeDataInput();
                    currencyData.WriteDataIntoFile(data);
                }
            }
            else
            {
                Console.WriteLine("Enter the symbol and rate of foreign currency ");
                Dictionary<string, double> data = TakeDataInput();
                currencyData.WriteDataIntoFile(data);
            }

            Console.Write("Enter The Symbol which you want to convert : ");
            string symbol = Console.ReadLine().ToUpper();

            Console.Write("Enter The amount of the currency : ");
            string rateString = Console.ReadLine();
            bool isValidRate = Double.TryParse(rateString, out double amount);
            if (!isValidRate)
            {
                Console.WriteLine($"{rateString} is not a valid Double input ");
            }

            double amountINR = currencyData.GetAmountINR(symbol, amount);
            // if amount is -1 that mean the provided symbol is not registered
            if (amountINR == -1)
            {
                Console.WriteLine("The currency symbol provided is not registered: ");
            }
            Console.WriteLine($"The Total amount in INR is {amountINR:0.00}");
        }

        //Function To Take Data as input from User like symbol and rate to be stored in file
        // and return the Dictionary containing all the data
        private static Dictionary<string, double> TakeDataInput()
        {
            Dictionary<string, double> data = new Dictionary<string, double>();

            char ch = 'y';
            int count = 1;
            while (ch == 'y')
            {
                Console.Write("Enter Currency Symbol: ");
                string symbol = Console.ReadLine();
                Console.Write("Enter Currency Rate: ");
                double rate = Convert.ToDouble(Console.ReadLine());

                //if user already enter this symbol then donot accept the input
                if (data.ContainsKey(symbol))
                {
                    Console.WriteLine("This symbol is already exist ");
                    continue;
                }
                data.Add(symbol, rate);

                if (count >= 5)
                {
                    Console.Write("More Enteries ?(y/n) :");
                    ch = Convert.ToChar(Console.ReadLine());
                }
                count++;
            }
            return data;
        }
    }
}