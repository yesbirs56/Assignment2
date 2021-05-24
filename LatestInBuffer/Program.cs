using System;
using System.Collections.Generic;

namespace LatestInBuffer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Queue<string> buffer = null;
            int n = 0;
            Console.WriteLine("Enter the buffer size");
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                string msg = "The entered value is not an integer";
                Console.WriteLine(msg);
                return;
                
            }
            catch (OverflowException)
            {
                Console.WriteLine("The entered value exceeds the integer maximum value");
                return;
            }

            try
            {
                buffer = new Queue<string>(n);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Buffer size cannot be negative");
                return;
            }

            while (true)
            {
                Console.WriteLine("Enter the Value");
                string temp = Console.ReadLine();
                if (temp == "?")
                {
                    PrintBuffer(buffer);
                    break;
                }
                if (buffer.Count == n)
                {
                    Console.WriteLine($"The buffer is full Want to overwrite oldest value = {buffer.Peek()} ?(y/n)");
                    char ch = Convert.ToChar(Console.ReadLine().ToLower());
                    if (ch == 'y')
                    {
                        buffer.Dequeue();
                    }
                    else
                    {
                        continue;
                    }
                }
                buffer.Enqueue(temp);
            }
        }

        // Print maximum latest 10 values entered
        private static void PrintBuffer(Queue<string> buffer)
        {
            int count = buffer.Count;
            int n = count - 10;
            int i = 0;
            Console.WriteLine("Latest 10 Values in Buffer are : ");
            foreach (string data in buffer)
            {
                if (i >= n)
                {
                    Console.Write(data + " ");
                }
                i++;
            }
        }
    }
}