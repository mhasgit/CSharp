using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ObjectOrientedTechniques
{
    abstract class AbstractCustomer
    {
        public AbstractCustomer()
        {
        }

        public AbstractCustomer(string CustomerID)
        {
        }


        public AbstractCustomer(string CustomerID, string CustomerName, string city, string region, string postalCode, string country)
        {
        }

        //properties of the abstract customer
        abstract public string CustomerID();
        abstract public string City();
        abstract public string Country();
        abstract public string CustomerName();
        abstract public string PostalCode();
        abstract public string Region();
        abstract public string Location();
        abstract public int AnnualSales();
        abstract public DateTime CustomerSince();
        abstract public int TotalSales();

        //Methods of the abstract Customer Class
        abstract public void UpdateLocation(string NewCity, string NewRegion, string NewPostalCode);
        abstract public void UpdateLocation(string NewCity, string NewRegion, string NewPostalCode, string NewCountry);
        abstract public void GetCustomerInfo(string customerID);
        abstract public void GetCustomerInfo(string customerID, ref string[] customerInfo);
        abstract public int SaveCustomer(string customerID, string customerName, string city, string region, string postalCode, string country);
        abstract public int SaveCustomer();
        abstract public string GetLocation(string _customerID, ref string _city, ref string _region, ref string _postalCode, ref string _country);
        abstract public void RecordSales(string customerID, int sales, int units);
        abstract public void RecordOrders(string customerID, params int[] Orders);

    }
}
