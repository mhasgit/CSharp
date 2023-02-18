using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedTechniques
{
    internal class TestAbstCustomer : AbstractCustomer
    {
        public override int AnnualSales()
        {
            throw new NotImplementedException();
        }

        public override string City()
        {
            throw new NotImplementedException();
        }

        public override string Country()
        {
            throw new NotImplementedException();
        }

        public override string CustomerID()
        {
            throw new NotImplementedException();
        }

        public override string CustomerName()
        {
            throw new NotImplementedException();
        }

        public override DateTime CustomerSince()
        {
            throw new NotImplementedException();
        }

        public override void GetCustomerInfo(string customerID)
        {
            throw new NotImplementedException();
        }

        public override void GetCustomerInfo(string customerID, ref string[] customerInfo)
        {
            throw new NotImplementedException();
        }

        public override string GetLocation(string _customerID, ref string _city, ref string _region, ref string _postalCode, ref string _country)
        {
            throw new NotImplementedException();
        }

        public override string Location()
        {
            throw new NotImplementedException();
        }

        public override string PostalCode()
        {
            throw new NotImplementedException();
        }

        public override void RecordOrders(string customerID, params int[] Orders)
        {
            throw new NotImplementedException();
        }

        public override void RecordSales(string customerID, int sales, int units)
        {
            throw new NotImplementedException();
        }

        public override string Region()
        {
            throw new NotImplementedException();
        }

        public override int SaveCustomer(string customerID, string customerName, string city, string region, string postalCode, string country)
        {
            throw new NotImplementedException();
        }

        public override int SaveCustomer()
        {
            throw new NotImplementedException();
        }

        public override int TotalSales()
        {
            throw new NotImplementedException();
        }

        public override void UpdateLocation(string NewCity, string NewRegion, string NewPostalCode)
        {
            throw new NotImplementedException();
        }

        public override void UpdateLocation(string NewCity, string NewRegion, string NewPostalCode, string NewCountry)
        {
            throw new NotImplementedException();
        }
    }
}
