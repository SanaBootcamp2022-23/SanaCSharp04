using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class Airplane
    {
        protected string StartCity;
        protected string FinishCity;
        protected Date StartDate;
        protected Date FinishDate;

        public string startCity
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    StartCity = value;
                }
            }
            get { return StartCity; }
        }
        public string finishCity
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    FinishCity = value;
                }
            }
            get { return FinishCity; }
        }
        public Date startDate
        {
            set
            {
                if (value != null)
                {
                    StartDate = new Date(value);
                }
            }
            get { return StartDate; }
        }
        public Date finishDate
        {
            set
            {
                if (value != null)
                {
                    FinishDate = new Date(value);
                }
            }
            get { return FinishDate; }
        }
        public Airplane()
        {
            StartCity = "No Data";
            FinishCity = "No Data";
            StartDate = new Date();
            FinishDate = new Date();
        }
        public Airplane(string startCity, string finishCity, Date startDate, Date finishDate)
        {
            StartCity = startCity;
            FinishCity = finishCity;
            StartDate = new Date(startDate);
            FinishDate = new Date(finishDate);
        }
        public Airplane(Date startDate, Date finishDate)
        {
            StartDate = new Date(startDate);
            FinishDate = new Date(finishDate);
        }
        public Airplane(Airplane airplane)
        {
            StartCity = airplane.StartCity;
            FinishCity = airplane.FinishCity;
            StartDate = new Date(airplane.StartDate);
            FinishDate = new Date(airplane.FinishDate);
        }
        public ulong GetTotalTime()
        {
            return FinishDate.SumTotalTime() - StartDate.SumTotalTime();
        }
        public bool IsArrivingToday()
        {
            if (StartDate.day == FinishDate.day && StartDate.month == FinishDate.month)
            {
                return true;
            }
            return false;
        }
    }
}