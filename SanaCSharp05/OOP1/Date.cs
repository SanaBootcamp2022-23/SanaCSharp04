using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class Date
    {
        protected int Year;
        protected int Month;
        protected int Day;
        protected int Hours;
        protected int Minutes;

        public int year
        {
            set
            {
                if (value > 1970)
                {
                    Year = value;
                }
            }
            get { return Year; }
        }
        public int month
        {
            set
            {
                if (value > 0 && value <= 12)
                {
                    Month = value;
                }
            }
            get { return Month; }
        }
        public int day
        {
            set
            {
                if (value > 0 && value <= 31)
                {
                    Day = value;
                }
            }
            get { return Day; }
        }
        public int hours
        {
            set
            {
                if (value > 0 && value <= 24)
                {
                    Hours = value;
                }
            }
            get { return Hours; }
        }
        public int minutes
        {
            set
            {
                if (value >= 0 && value <= 60)
                {
                    Minutes = value;
                }
            }
            get { return Minutes; }
        }
        public Date()
        {
            Year = 0;
            Month = 0;
            Day = 0;
            Hours = 0;
            Minutes = 0;
        }
        public Date(int year, int month, int day, int hours, int minutes)
        {
            Year = year;
            Month = month;
            Day = day;
            Hours = hours;
            Minutes = minutes;
        }
        public Date(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
            Hours = 0;
            Minutes = 0;
        }
        public Date(Date date)
        {
            Year = date.Year;
            Month = date.Month;
            Day = date.Day;
            Hours = date.Hours;
            Minutes = date.Minutes;
        }
        public ulong SumTotalTime()
        {
            ulong SumMinutes = (ulong)Minutes;
            SumMinutes += (ulong)Hours * 60;
            SumMinutes += (ulong)Day * 1440;
            SumMinutes += (ulong)Month * 43800;
            SumMinutes += (ulong)Year * 525960;
            return SumMinutes;
        }
    }
}