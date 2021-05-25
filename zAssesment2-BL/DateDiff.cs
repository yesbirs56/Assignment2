using System;

namespace Assesment2_BL
{
    public class DateDiff
    {
        private readonly static int[] _daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        readonly private DateTime _startDate;
        readonly private DateTime _endDate;

        /// <summary>
        /// Total Number of days between StartDate and EndDate
        /// </summary>
        public double TotalDays { get; }

        /// <summary>
        ///  Number of days Between StartDate and EndDate
        /// </summary>
        public int Days { get; }

        /// <summary>
        ///  Number of months Between StartDate and EndDate
        /// </summary>
        public int Months { get; }

        /// <summary>
        ///  Number of years Between StartDate and EndDate
        /// </summary>
        public int Years { get; }

        // Funtion to check the order of date if order is wrong it swaps dates
        private static bool ValidateDateOrder(DateTime startDate, DateTime endDate)
        {
            int compareResult = startDate.CompareTo(endDate);

            if (compareResult > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Function return boolean value to indicate EndDate is LeapYear or Not
        private static bool IsLeapYear(int year)
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

        //Constructor of DayDiff and Set the Values of Properties
        /// <summary>
        /// Initializes a new instance of the Assesment2_BL.DateDiff and accepts startDate and endDate of type DateTime
        /// </summary>
        /// <param name="startDate"> Start Date </param>
        /// <param name="endDate"> End Date</param>
        public DateDiff(DateTime startDate, DateTime endDate)
        {
            if (ValidateDateOrder(startDate, endDate))
            {
                this._startDate = startDate;
                this._endDate = endDate;
            }
            else
            {
                this._endDate = startDate;
                this._startDate = endDate;
            }
            this.TotalDays = SetDaysDiff();
            (this.Days, this.Months, this.Years) = SetProps();
        }

        //Function contains logic to calculate Days Months and Years
        private (int, int, int) SetProps()
        {
            if (IsLeapYear(this._endDate.Year))
            {
                _daysInMonth[1] = 29;
            }
            int yearDiff = _endDate.Year - _startDate.Year;
            int monthDiff = (_endDate.Month - _startDate.Month);
            int dayDiff = _endDate.Day - _startDate.Day;

            //If dayDiff is negative then month decreases
            if (dayDiff < 0)
            {
                monthDiff--;
                dayDiff = _daysInMonth[(this._endDate.Month + 12 - 2) % 12] - this._startDate.Day + this._endDate.Day;
            }
            //If monthDiff is negative year is decrease
            if (monthDiff < 0)
            {
                monthDiff = 12 - Math.Abs(monthDiff);
                yearDiff--;
            }
            return (dayDiff, monthDiff, yearDiff);
        }

        // Function to set Total days
        private double SetDaysDiff()
        {
            TimeSpan diff = this._endDate - this._startDate;
            double daysDiff = diff.TotalDays;

            return daysDiff;
        }
    }
}