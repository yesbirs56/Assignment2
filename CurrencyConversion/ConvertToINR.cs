using System;
using System.IO;

namespace CurrencyConversion
{
    internal class ConvertToINR
    {
        public static void Main(string[] args)
        {
            string path = $@"{Directory.GetCurrentDirectory()}\currency.dat";

            FileInfo currencyData = new FileInfo(path);
            if (currencyData.Exists)
            {
                Console.WriteLine("Do you want to Continue with existing Data Or Create New One ? (y/n)");
                char ch = 'n';
                try
                {
                    ch = Convert.ToChar(Console.ReadLine());
                }
                catch (FormatException exception)
                {
                    string msg = "The entered value is not a character";
                    Console.WriteLine(exception.Message);
                }

                if (ch == 'y')
                {
                    WriteDataIntoFile(currencyData);
                }
            }
            else
            {
                WriteDataIntoFile(currencyData);
            }

            Conversion(currencyData);
        }

        private static void Conversion(FileInfo currencyData)
        {
            Console.Write("Enter the foreign currency Symbol  : ");
            string symbol = Console.ReadLine();
            Console.Write("Enter the Amount: ");
            double amount = 0;
            try
            {
                amount = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Entered the wrong value");
            }

            double rate = GetRate(currencyData, symbol);
            if (rate == -1)
            {
                Console.WriteLine("This currency symbol is not registered");
                return;
            }

            double inr = ConvertCurrency(amount, rate);
            Console.WriteLine($"{amount} {symbol} is equal to : {String.Format("{0:0.00}", inr)} INR");
        }

        private static double GetRate(FileInfo currencyData, string symbol)
        {
            BinaryReader br = new BinaryReader(currencyData.OpenRead());
            while (br.PeekChar() != -1)
            {
                string sym = br.ReadString();
                if (sym == symbol)
                {
                    double rate = br.ReadDouble();
                    br.Close();
                    return rate;
                }
                br.ReadDouble();
            }
            br.Close();
            return -1;
        }

        private static double ConvertCurrency(double amount, double rate)
        {
            return amount * rate;
        }

        private static void WriteDataIntoFile(FileInfo currencyData)
        {
            BinaryWriter bw = new BinaryWriter(currencyData.OpenWrite());
            char ch = 'y';
            int count = 1;
            while (ch == 'y')
            {
                Console.Write("Enter Currency Symbol: ");
                string symbol = Console.ReadLine();
                Console.Write("Enter Currency Rate: ");
                double rate = Convert.ToDouble(Console.ReadLine());
                bw.Write(symbol);
                bw.Write(rate);
                if (count >= 5)
                {
                    Console.Write("More Enteries ?(y/n) :");
                    ch = Convert.ToChar(Console.ReadLine());
                }
                count++;
            }
            bw.Close();
        }
    }
}