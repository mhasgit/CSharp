using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedTechniques
{
    internal class TestInterface : ICustomer
    {
        public string CustomerID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CustomerName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PostalCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Region { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Location { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void GetCustomerInfo(string customerID, ref string[] customerInfo)
        {
            throw new NotImplementedException();
        }

        public string GetLocation()
        {
            throw new NotImplementedException();
        }

        public void RecordSales(string customerID, int sales, int units)
        {
            throw new NotImplementedException();
        }

        public int SaveCustomer()
        {
            throw new NotImplementedException();
        }

        public void UpdateLocation(string NewCity, string NewRegion, string PostalCode)
        {
            throw new NotImplementedException();
        }
    }

    class TestInterface2 : ICustomer
    {
        string ICustomer.CustomerID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string ICustomer.CustomerName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string ICustomer.City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string ICustomer.PostalCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string ICustomer.Region { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string ICustomer.Location { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        void ICustomer.GetCustomerInfo(string customerID, ref string[] customerInfo)
        {
            throw new NotImplementedException();
        }

        string ICustomer.GetLocation()
        {
            throw new NotImplementedException();
        }

        void ICustomer.RecordSales(string customerID, int sales, int units)
        {
            throw new NotImplementedException();
        }

        int ICustomer.SaveCustomer()
        {
            throw new NotImplementedException();
        }

        void ICustomer.UpdateLocation(string NewCity, string NewRegion, string PostalCode)
        {
            throw new NotImplementedException();
        }
    }
}
