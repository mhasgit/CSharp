using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedTechniques
{
	interface ICustomer
	{
		string CustomerID
		{
			get;
			set;
		}

        string CustomerName
		{
			get;
			set;
		}

		string City
		{
			get;
			set;
		}

		string PostalCode
		{
			get;
			set;
		}

		string Region
		{
			get;
			set;
		}

		string Location
		{
			get;
			set;
		}

		string GetLocation();
		void GetCustomerInfo(string customerID, ref string[] customerInfo);
		int SaveCustomer();

		void RecordSales(string customerID, int sales, int units);
		void UpdateLocation(string NewCity, string NewRegion, string PostalCode);
	}
}
