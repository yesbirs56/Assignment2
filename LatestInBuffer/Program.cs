using Assesment2_BL;
using System;

namespace LatestInBuffer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            FixedBuffer buffer;
            

            Console.WriteLine("Enter the buffer size");

            string bufferSize = Console.ReadLine();
            bool isValidN = Int32.TryParse(bufferSize, out int n);
            if (!isValidN)
            {
                Console.WriteLine($"{bufferSize} is not a valid integer");
            }

            try
            {
                buffer = new FixedBuffer(n);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Buffer size cannot be negative");
                return;
            }
            
            catch(Exception exc)
            {
                Console.WriteLine($"{exc.Message}");
                return;
            }

            

            while (true)
            {
                Console.Write($"Enter the Data  : ");
                string data = Console.ReadLine();
                if (data == "?")
                {
                    break;
                }
                if (buffer.IsBufferFull())
                {
                    
                    Console.Write($"Buffer is full want to over write oldest value {buffer.GetOldestData()} ?(y/n) : ");
                    string ans = Console.ReadLine().ToLower();
                    if (ans != "n")
                    {
                        
                        try
                        {
                            buffer.OverWriteOldestData(data);

                        }
                        catch (InvalidOperationException exc)
                        {
                            Console.WriteLine(exc.Message);
                            return;
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                            return;
                        }
                    }
                    continue;
                }
                buffer.AddData(data);
                
               
                
            }

            string[] values = buffer.GetBufferData();
            PrintBuffer(values);
        }

        // Print The Buffer Data
        private static void PrintBuffer(string[] buffer)
        {
            Console.WriteLine("The Data in buffer ");
            foreach (string data in buffer)
            {
                Console.Write($"{data} ");
            }
        }
    }
}