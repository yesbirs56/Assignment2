using Assesment2_BL;
using System;
using System.Collections.Generic;

namespace CurrencyConversion
{
    internal class ConvertToINR
    {
        public static void Main(string[] args)
        {
            string path = $@"{AppDomain.CurrentDomain.BaseDirectory}..\..\..\currency.dat";

            CurrencyConverter currencyData = new CurrencyConverter(path); ;
            if (currencyData.IsDataExist())
            {
                Console.WriteLine("Do you want to Enter New Data list ? (y/n)");

                bool isChar = Char.TryParse(Console.ReadLine(), out char ch);
                if (!isChar)
                {
                    ch = 'n';
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

            Console.WriteLine("Available Currencies are :");
            List<string> registeredSymbols = currencyData.GetSymbols();

            foreach (var registeredSymbol in registeredSymbols)
            {
                Console.Write($"{registeredSymbol} ");
            }

            Console.Write("\nEnter The Symbol which you want to convert : ");
            string symbol = Console.ReadLine().ToUpper();
            while (!currencyData.IsCurrencyRegistered(symbol))
            {
                Console.WriteLine("The Entered Symbol is not registered");
                Console.Write("\nEnter The Symbol which you want to convert : ");
                symbol = Console.ReadLine().ToUpper();
            }

            Console.Write("Enter The amount of the currency : ");
            string rateString = Console.ReadLine();
            bool isValidRate = Double.TryParse(rateString, out double amount);
            while (!isValidRate)
            {
                Console.WriteLine($"{rateString} is not a valid Double input ");
                Console.Write("Enter The amount of the currency : ");
                rateString = Console.ReadLine();
                isValidRate = Double.TryParse(rateString, out amount);
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
                string symbol = "";
                do 
                { 
                    Console.Write("Enter Currency Symbol: ");
                    symbol = Console.ReadLine();
                    if (symbol.Length != 3)
                    {
                        Console.WriteLine("Symbol must be of length 3");
                    }
                } while(symbol.Length!=3);
                Console.Write("Enter Currency Rate: ");
                string rateString = Console.ReadLine();
                bool isValidRate = Double.TryParse(rateString, out double rate);
                while (!isValidRate)
                {
                    Console.WriteLine($"{rateString} is not a valid Double input ");
                    rateString = Console.ReadLine();
                    isValidRate = Double.TryParse(rateString, out rate);
                }

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