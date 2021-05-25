using Assesment2_BL;
using System;
using System.Globalization;

namespace Assignment1
{
    internal class DateDifference
    {
        private static readonly DateTime _today = DateTime.Today;
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the Date in MM/dd/yyyy format :");
            Console.Write("For example if date is 1 March 2001");
            Console.WriteLine(" Write 03/01/2001 ");
            Console.WriteLine();



            DateTime startDate = TakeDateInput("Enter Start Date : ");
            while (!ValidateStartDate(startDate))
            {
                Console.WriteLine("The StartDate date should occur before Today's Date ");
                startDate = TakeDateInput("Enter Start Date : ");
            }
            DateTime endDate = TakeDateInput("Enter End Date : ");
            while (!ValidateEndDate(endDate, startDate))
            {
                Console.WriteLine("The End date should occur later then Start Date ");
                endDate = TakeDateInput("Enter End Date : ");
            }

            
            DateDiff diff = new DateDiff(startDate, endDate);

            Console.WriteLine($" Total number of days {diff.TotalDays}");
            Console.WriteLine($"Months: {diff.Years * 12 + diff.Months} : Days:{diff.Days}");
            Console.WriteLine($"Years :{diff.Years}  Months: {diff.Months} Days:{diff.Days}");
        }
        // The Function used take date input

        private static DateTime TakeDateInput(string msg )
        {
            string dateString = "";
            Console.Write(msg);
            dateString = Console.ReadLine();
            while (!ValidateDateString(dateString)){
                Console.WriteLine("You have enter the wrong date please enter corect date in format MM/dd/yyyyy :");
                Console.Write(msg);
                dateString = Console.ReadLine();

            }

            string[] dateDetails = dateString.Split("/");
            int month = Convert.ToInt32(dateDetails[0].Trim());
            int day = Convert.ToInt32(dateDetails[1].Trim());
            int year = Convert.ToInt32(dateDetails[2].Trim());


            return new DateTime(year,month,day);

            

        }
        // Function to Validate StartDate return true if start date is valid  else false
        private static bool ValidateStartDate(DateTime startDate)
        {
            if (startDate.CompareTo(_today)>=0){
                return false;
            }
            return true;
        }

        //Function to Validate EndDate returns true if end date is valid or false if not
        private static bool ValidateEndDate(DateTime endDate, DateTime startDate)
        {
            if (endDate.CompareTo(startDate) <= 0)
            {
                return false;
            }
            return true;
        }

        //Funtion to Validte Date String return true if dateString is Valid or false if not
        private static bool ValidateDateString(string dateString)
        {
            if (dateString.Length == 0)
            {
                return false;
            }
            string[] dateDetails = dateString.Split("/");
            

            if (dateDetails.Length != 3)
            {
                return false;
            }
            int day = -1;
            int year = -1;
            
            bool isValidInt = Int32.TryParse(dateDetails[0].Trim(), out int month); 
            isValidInt = isValidInt && Int32.TryParse(dateDetails[1].Trim(), out  day);
            isValidInt = isValidInt && Int32.TryParse(dateDetails[2].Trim(), out  year);
            if (!isValidInt)
            {
                return false;
            }
            bool isValid = (month >= 1 && month <= 12);
            isValid = isValid && (day >= 1 && day <= DateDiff.DaysInMonth[month - 1]);
            isValid = isValid && (year >= 1 && year <=9999);

            if (!isValid)
            {
                return false;
            }
            return true;

        }
    }
}