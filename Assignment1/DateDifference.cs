using Assesment2_BL;
using System;
using System.Globalization;

namespace Assignment1
{
    internal class DateDifference
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter the Date in MM/dd/yyyy format :");
            Console.Write("For example if date is 1 March 2001");
            Console.WriteLine(" Write 03/01/2001 ");
            Console.WriteLine();

            DateTime dateFrom = TakeDateInput("Enter Date from (MM/dd/yyyy) : ");


            DateTime dateTo = new DateTime();
            bool isValid = false;
            

            while (!isValid)
            {
                
                try
                {
                    dateTo = TakeDateInput("Enter Date To (MM/dd/yyyy) : ");
                    int compareResult = dateFrom.CompareTo(dateTo);

                    if (compareResult > 0)
                    {
                        Console.WriteLine("The End Date cannot be earlier then From Date :");
                        continue;
                    }
                    
                    isValid = true;
                }
                catch (FormatException exc)
                {
                    Console.WriteLine(exc.Message);
                }
                catch (ArgumentOutOfRangeException exc)
                {
                    Console.WriteLine("Date Does not Exist enter Correct date" + exc.Message);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(Exception exc)
                {
                    Console.WriteLine($"{exc.Message}");
                }
            }
            
            DateDiff diff = new DateDiff(dateFrom, dateTo);

            Console.WriteLine($" Total number of days {diff.TotalDays}");
            Console.WriteLine($"Months: {diff.Years * 12 + diff.Months} : Days:{diff.Days}");
            Console.WriteLine($"Years :{diff.Years}  Months: {diff.Months} Days:{diff.Days}");
        }
        // The Function used take date input
        public static DateTime TakeDateInput(string msg = "")
        {
            try
            {
                Console.Write(msg);
                string date1 = Console.ReadLine().Trim();
                string[] date1Details = date1.Split("/");
                string[] formats = { "MM/dd/yyyy" };
                
                
                int month = Convert.ToInt32(date1Details[0]);
                int day = Convert.ToInt32(date1Details[1]);
                int year = Convert.ToInt32(date1Details[2]);

                DateTime date = new DateTime(year, month, day);
                return date;
            }
            catch (FormatException)
            {
                
                throw;
            }
            catch (ArgumentOutOfRangeException)
            {
                
                throw;
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
            catch(Exception )
            {
                throw;
            }
        }
    }
}