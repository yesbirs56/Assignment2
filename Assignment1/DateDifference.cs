using System;

namespace Assignment1
{
    internal class DateDifference
    {
        private readonly static int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        private static void Main(string[] args)
        {
            Console.WriteLine("Enter the Date in MM/dd/yyyy format :");
            Console.Write("For example if date is 1 March 2001");
            Console.WriteLine(" Write 03/01/2001 ");
            Console.WriteLine();

            DateTime dateFrom = TakeDateInput("Enter Date From (MM/dd/yyyy) : ");

            bool isValid = true;
            DateTime dateTo = new DateTime();
            while (isValid)
            {
                dateTo = TakeDateInput("Enter Date To (MM/dd/yyyy) : ");

                int compareResult = dateFrom.CompareTo(dateTo);
                if (compareResult > 0)
                {
                    Console.WriteLine("Date To should Not be before Date From");
                    
                }
                else
                {
                    isValid = false;
                }
            }

            // If end year is leap year then days in feb is 29
            if (isLeapYear(dateTo.Year))
            {
                daysInMonth[1] = 29;
            }
            int yearDiff = dateTo.Year - dateFrom.Year;
            int monthDiff = (dateTo.Month - dateFrom.Month);
            int dayDiff = dateTo.Day - dateFrom.Day;

            // If day of end month is less day of start month then
            // month difference decrease by 1 and calculate day from previous month
            if (dayDiff < 0)
            {
                monthDiff--;
                dayDiff = daysInMonth[(dateTo.Month+12 - 2)%12] - dateFrom.Day + dateTo.Day;
            }
            // If month is negative thenyear is decrease by one and calculate correct month difference
            if (monthDiff < 0)
            {
                monthDiff = 12 - Math.Abs(monthDiff);
                yearDiff--;
            }

            TimeSpan diff = dateTo - dateFrom;
            double daysDiff = diff.TotalDays;
            Console.WriteLine("Total Days : " + daysDiff);

            int totalMonths = yearDiff * 12 + monthDiff;
            Console.WriteLine($"months: {totalMonths}  days:{dayDiff}");

            Console.WriteLine($"year: {yearDiff}  months: {monthDiff}  days: {dayDiff}");
        }

        // Function to return true if year is leap year false if not

        private static bool isLeapYear(int year)
        {
            if (year % 100 == 0 && year % 400 != 0)
            {
                return false;
            }
            else if (year % 4 == 0)
            {
                return true;
            }

            return false;
        }

        // Funtion to take date input and return DateTime object
        private static DateTime TakeDateInput(string msg = "")
        {
            try
            {
                Console.Write(msg);
                string date1 = Console.ReadLine().Trim();
                string[] date1Details = date1.Split("/");
                int month = Convert.ToInt32(date1Details[0]);
                int day = Convert.ToInt32(date1Details[1]);
                int year = Convert.ToInt32(date1Details[2]);

                DateTime date = new DateTime(year, month, day);
                return date;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please Enter in Correct Format (MM/dd/yyyy)");
                return TakeDateInput(msg);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Date Does not Exist enter Correct date");
                return TakeDateInput(msg);
            }
        }
    }
}