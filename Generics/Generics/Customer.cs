using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Generics
{
    public class Customer
    {
            private string _City;
            private string _Country = _DefaultCountry;
            private string _CustomerID;
            private string _CustomerName;
            private string _PostalCode;
            private string _Region;
            protected static int CumulativeSales = 0;

            public Customer()
            {

            }

            /// <param name="CustomerID">ID for the new customer</param>
            public Customer(string CustomerID)
            {
                _CustomerID = CustomerID;
            }


            public Customer(string CustomerID, string CustomerName, string city, string region, string postalCode, string country)
            {
                _CustomerID = CustomerID;
                _CustomerName = CustomerName;
                _City = city;
                _Region = region;
                _PostalCode = postalCode;
                _Country = country;

                SaveCustomer();
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

            public void UpdateLocation(string NewCity, string NewRegion, string NewPostalCode)
            {
                _City = NewCity;
                _Region = NewRegion;
                _PostalCode = NewPostalCode;
            }

            public void UpdateLocation(string NewCity, string NewRegion, string NewPostalCode, string NewCountry)
            {
                _City = NewCity;
                _Region = NewRegion;
                _PostalCode = NewPostalCode;
                _Country = NewCountry;
            }

            //Method
            public string GetLocation()
            {
                return string.Format("{0} {1} {2}", _City, _Region, _PostalCode);
            }

            //Property
            public string Location
            {
                get
                {
                    return string.Format("{0} {1} {2}", _City, _Region, _PostalCode);
                }
            }

            public override string ToString()
            {
                return string.Format("{0} ({1})", _CustomerName, _Country);
            }

            public static bool IsInUSA(Customer mycustomer)
            {
                return (mycustomer.Country == "USA");
            }
            public static bool IsNotInUSA(Customer mycustomer)
            {
                return (mycustomer.Country != "USA");
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

            public int AnnualSales
            {
                get
                {
                    Random randomNumber = new Random();
                    return randomNumber.Next();
                }
            }

            public DateTime CustomerSince { get; set; }

            public int TotalSales
            {
                get
                { return cumulativeSales; }
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

            public int SaveCustomer(string customerID, string customerName, string city, string region, string postalCode, string country)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineChars = "\r\n";

                XmlWriter writer = XmlWriter.Create(string.Format(@"c:\{0}.xml", customerID), settings);

                writer.WriteStartDocument(true);
                writer.WriteStartElement("Cutomer");
                writer.WriteElementString("CutomerID", customerID);
                writer.WriteElementString("CustomerName", customerName);
                writer.WriteElementString("City", city);
                writer.WriteElementString("Region", region);
                writer.WriteElementString("PostalCode", postalCode);
                writer.WriteElementString("Country", country);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                if (File.Exists(string.Format(@"c:\{0}.xml", customerID)))
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

            public int SaveCustomer()
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineChars = "\r\n";

                XmlWriter writer = XmlWriter.Create(string.Format(@"c:\{0}.xml", this.CustomerID), settings);

                writer.WriteStartDocument(true);
                writer.WriteStartElement("Cutomer");
                writer.WriteElementString("CutomerID", this.CustomerID);
                //writer.WriteElementString("CustomerName", this.CutomerName);
                writer.WriteElementString("City", this.City);
                writer.WriteElementString("Region", this.Region);
                writer.WriteElementString("PostalCode", this.PostalCode);
                writer.WriteElementString("Country", this.Country);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                if (File.Exists(string.Format(@"c:\{0}.xml", this.CustomerID)))
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

            public string GetLocation(string _customerID, ref string _city, ref string _region, ref string _postalCode, ref string _country)
            {
                string _companyName = null;
                XmlReader reader = XmlReader.Create((string.Format(@"c:\{0}.xml", _customerID)));

                while (reader.ReadToFollowing("Customer"))
                {

                    reader.ReadToFollowing("CustomerName");
                    _companyName = reader.ReadInnerXml();
                    reader.ReadToFollowing("City");
                    _city = reader.ReadInnerXml();
                    reader.ReadToFollowing("Region");
                    _region = reader.ReadInnerXml();
                    reader.ReadToFollowing("PostalCode");
                    _postalCode = reader.ReadInnerXml();
                    reader.ReadToFollowing("Country");
                    _country = reader.ReadInnerXml();

                }

                return _companyName;
            }

            private static int cumulativeSales = 0;
            public void RecordSales(string customerID, int sales, int units)
            {
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

                XmlWriter writer = XmlWriter.Create(string.Format(@"c:\{0}_Orders.xml", this.CustomerID), settings);

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

            public static string GetCustomerName(string customerID)
            {
                XmlReader reader = XmlReader.Create(string.Format(@"c:\{0}.xml", customerID));

                string customerName = string.Empty;
                while (reader.ReadToFollowing("Customer"))
                {
                    reader.ReadToFollowing("CustomerName");
                    customerName = reader.ReadInnerXml();
                }
                return customerName;
            }
    }
}
