using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ObjectOrientedTechniques
{
    public partial class Customer2
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
    }
}
