using System.Collections.Generic;
using System.IO;

namespace Assesment2_BL
{
    /// <summary>
    /// Provide the Writing the currency symbol and rate into file and give the amount in INR
    /// </summary>
    public class CurrencyConverter
    {
        // the path of the file
        private readonly string _path;

        /// <summary>
        /// check if Data already exist or not
        /// </summary>
        /// <returns>true if file exist false if not</returns>
        public bool IsDataExist()
        {
            FileInfo file = new FileInfo(this._path);
            return file.Exists;
        }

        /// <summary>
        /// Writes the Dictionary<string,double> data into file
        /// </summary>
        /// <param name="data"></param>
        public void WriteDataIntoFile(Dictionary<string, double> data)
        {
            FileInfo currencyData = new FileInfo(this._path);
            if (IsDataExist())
            {
                currencyData.Delete();
            }
            BinaryWriter bw = new BinaryWriter(currencyData.OpenWrite());

            foreach (var item in data)
            {
                bw.Write(item.Key);
                bw.Write(item.Value);
            }
            bw.Close();
        }

        /// <summary>
        /// Gives Amount in INR
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="amount"></param>
        /// <returns>-1 if symbol is not registered else return the amount in INR</returns>
        public double GetAmountINR(string symbol, double amount)
        {
            double rate = GetRate(symbol);
            if (rate == -1)
            {
                return -1;
            }

            double inr = rate * amount;
            return inr;
        }
        private double GetRate(string symbol)
        {
            FileInfo currencyData = new FileInfo(this._path);
            using (BinaryReader br = new BinaryReader(currencyData.OpenRead()))
            {
                while (br.PeekChar() != -1)
                {
                    string sym = br.ReadString();
                    if (sym == symbol)
                    {
                        double rate = br.ReadDouble();
                        return rate;
                    }
                    br.ReadDouble();
                }
                
            }
               
            return -1;

        }

        // private method for getting the rate of the symbol
        public bool IsCurrencyRegistered(string symbol)
        {
            FileInfo currencyData = new FileInfo(this._path);
            using (BinaryReader br = new BinaryReader(currencyData.OpenRead()))
            {
                while (br.PeekChar() != -1)
                {
                    string sym = br.ReadString();
                    if (sym == symbol)
                    {
                        return true;
                    }
                    br.ReadDouble();
                }
            }
            return false;
        }


        public List<string> GetSymbols()
        {
            List<string> symbols = new List<string>();
            FileInfo currencyData = new FileInfo(this._path);
            BinaryReader br = new BinaryReader(currencyData.OpenRead());
            while (br.PeekChar() != -1)
            {
                string symbol = br.ReadString();
                symbols.Add(symbol);
                br.ReadDouble();
            }
            br.Close();
            return symbols;
        }

        /// <summary>
        /// expose the Instance the Assesment2_BL.CurrencyConverter<br/>
        /// initialize with one string parameter
        /// which is path of the data file
        /// </summary>
        /// <param name="path"></param>
        public CurrencyConverter(string path)
        {
            this._path = path;
        }
    }
}