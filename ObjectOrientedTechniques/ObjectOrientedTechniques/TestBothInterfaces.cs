using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedTechniques
{
    internal class TestBothInterfaces : ICustomer, ICorporateSales
    {
        public string CustomerID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CustomerName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PostalCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Region { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Location { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int CreditLimit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ChangeCreditLimit(int changeAmount)
        {
            throw new NotImplementedException();
        }

        public void GetCustomerInfo(string customerID, ref string[] customerInfo)
        {
            throw new NotImplementedException();
        }

        public string GetLocation()
        {
            throw new NotImplementedException();
        }

        public void RecordOrders(string customerID, params int[] Orders)
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
}
