using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ObjectOrientedTechniques
{
    internal class IndividualCustomer : Customer
    {
        private string _FirstName;
        private string _LastName;
        private int _BirthdayMonth;
        private int _BirthdayDay;
        private int Index;

        public string FirstName
        {
            get
            { return _FirstName; }
            set
            { _FirstName = value; }
        }

        public string LastName
        {
            get
            { return _LastName; }
            set
            { _LastName = value; }
        }

        public override string CustomerName 
        {
            get
            { return _FirstName + " " + _LastName; }

            set
            {
                Index = value.IndexOf(" ");
                _FirstName = value.Substring(0, Index);
                _LastName = value.Substring(Index + 1);
            }

        }

        public int BirthdayMonth
        {
            get
            { return _BirthdayMonth; }
            set
            { _BirthdayMonth = value; }
        }

        public int BirthdayDay
        {
            get
            { return _BirthdayDay; }
            set
            { _BirthdayDay = value; }
        }

        public void RecordSales(string customerID, int birthdayMonth, int birthdayDay, int sales, int units)
        {
            if (DateTime.Today.Month == birthdayMonth && DateTime.Today.Day == birthdayDay)
            {
                sales = Convert.ToInt32(sales * 0.8);
            }
            base.RecordSales(customerID, sales, units);
        }


    }
}
