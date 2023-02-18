using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ObjectOrientedTechniques
{
    internal class Customer3
    {
        public class Information
        {
            private string _City;
            private string _Country = " ";//_DefaultCountry;
            private string _CustomerID;
            private string _CustomerName;
            private string _PostalCode;
            private string _Region;
            protected static int CumulativeSales = 0;

            public Information()
            {

            }

            public Information(string CustomerID)
            {
                _CustomerID = CustomerID;
            }


            public Information(string customerID, string customerName, string city, string region, string postalCode, string country)
            {
                _CustomerID = customerID;
                _CustomerName = customerName;
                _City = city;
                _Region = region;
                _PostalCode = postalCode;
                _Country = country;

                //SaveCustomer();
            }

            public string CustomerID
            {
                get
                {
                    return _CustomerID;
                }
            }

            public string City
            {
                get
                {
                    return _City;
                }
                set
                {
                    _City = value;
                }
            }

            public string Country
            {
                get
                {
                    return _Country;
                }
                set
                {
                    _Country = value;
                }
            }

            public virtual string CustomerName
            {
                get
                {
                    return _CustomerName;
                }
                set
                {
                    _CustomerName = value;
                }
            }

            public string PostalCode
            {
                get
                {
                    return _PostalCode;
                }
                set
                {
                    _PostalCode = value;
                }
            }

            public string Region
            {
                get
                {
                    return _Region;
                }
                set
                {
                    _Region = value;
                }
            }

            public void GetCustomerInfo(string customerID)
            {
                XmlReader reader = XmlReader.Create((string.Format(@"c:\{0}.xml", customerID)));

                while (reader.ReadToFollowing("Customer"))
                {
                    reader.ReadToFollowing("CustomerID");
                    //this.CustomerID = reader.ReadInnerXml();
                    reader.ReadToFollowing("CustomerName");
                    this.CustomerName = reader.ReadInnerXml();
                    reader.ReadToFollowing("City");
                    this.City = reader.ReadInnerXml();
                    reader.ReadToFollowing("Region");
                    this.Region = reader.ReadInnerXml();
                    reader.ReadToFollowing("PostalCode");
                    this.PostalCode = reader.ReadInnerXml();
                    reader.ReadToFollowing("Country");
                    this.Country = reader.ReadInnerXml();

                }
            }

            public void GetCustomerInfo(string customerID, ref string[] customerInfo)
            {
                XmlReader reader = XmlReader.Create((string.Format(@"c:\{0}.xml", customerID)));

                while (reader.ReadToFollowing("Customer"))
                {
                    reader.ReadToFollowing("CustomerID");
                    customerInfo[0] = reader.ReadInnerXml();
                    reader.ReadToFollowing("CustomerName");
                    customerInfo[1] = reader.ReadInnerXml();
                    reader.ReadToFollowing("City");
                    customerInfo[2] = reader.ReadInnerXml();
                    reader.ReadToFollowing("Region");
                    customerInfo[3] = reader.ReadInnerXml();
                    reader.ReadToFollowing("PostalCode");
                    customerInfo[4] = reader.ReadInnerXml();
                    reader.ReadToFollowing("Country");
                    customerInfo[5] = reader.ReadInnerXml();

                }
            }

            private static string _DefaultCountry = "UK";
            public static string DefaultCountry
            {
                get
                {
                    return _DefaultCountry;
                }
                set
                {
                    _DefaultCountry = value;
                }
            }

            public string Location
            {
                get
                {
                    return string.Format("{0} {1} {2}", _City, _Region, _PostalCode);
                }
            }

            public DateTime CustomerSince { get; set; }
    }

        public class Financial
        {
            protected static int cumulativeSales = 0;

            public int AnnualSales
            {
                get
                {
                    Random randomNumber = new Random();
                    return randomNumber.Next();
                }
            }

            public int TotalSales
            {
                get
                { return cumulativeSales; }
            }

            public void RecordSales(string customerID, int sales, int units)
            {
                TaxCalculatoor taxCalc = new TaxCalculatoor();
                Customer3.Information customerInfo = new Customer3.Information();
                customerInfo.GetCustomerInfo(customerID);
                sales = (int)(sales * (1 + taxCalc.FindTax(customerInfo.Region)));
                
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineChars = "\r\n";

                XmlWriter writer = XmlWriter.Create(string.Format(@"c:\{0}_Sales.xml", customerID), settings);

                writer.WriteStartDocument(true);
                writer.WriteStartElement("CutomerSales");
                writer.WriteElementString("CutomerID", customerID);
                writer.WriteElementString("Sals", sales.ToString());

                if (units == -1)
                {
                    writer.WriteElementString("Units", "Unknown");
                }
                else
                {
                    writer.WriteElementString("Units", units.ToString());
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                cumulativeSales += sales;
            }

            public void RecordOrders(string customerID, params int[] Orders)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineChars = "\r\n";

                XmlWriter writer = XmlWriter.Create(string.Format(@"c:\{0}_Orders.xml", customerID), settings);

                writer.WriteStartDocument(true);
                writer.WriteStartElement("Orders");
                for (int counter = 0; counter < Orders.Length; counter++)
                {
                    writer.WriteStartElement("Order");
                    writer.WriteElementString("CustomerID", customerID);
                    writer.WriteElementString("OrderID", Orders[counter].ToString());
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

            }
        }

        public class TaxCalculatoor
        {
            public TaxCalculatoor()
            {

            }

            public double FindTax(string region)
            {
                switch (region)
                {
                    case "WA":
                        return 0.065;
                    case "MN":
                        return 0.065;
                    case "CA":
                        return 0.06;
                    default:
                        return 0.05;
                }
            }
        }
    }
}
