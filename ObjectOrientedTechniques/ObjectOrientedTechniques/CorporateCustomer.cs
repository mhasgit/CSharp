using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ObjectOrientedTechniques
{
    internal class CorporateCustomer : Customer
    {
        private string _SalesRep;
        private int _CreditLimit;

        public string SalesRep
        {
            get { return _SalesRep; }
            set { _SalesRep = value; }
        }

        public int CreditLimit
        {
            get
            { return _CreditLimit; }
            set
            { _CreditLimit = value; }
        }

        public void ChangeCreditLimit(int changeAmount)
        {
            _CreditLimit = changeAmount;
        }

        public void RecordSales(string customerID, string salesRep, int sales, int units)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineChars = "\r\n";

            XmlWriter writer = XmlWriter.Create(string.Format(@"c:\{0}_Sales.xml", customerID), settings);

            writer.WriteStartDocument(true);
            writer.WriteStartElement("CutomerSales");
            writer.WriteElementString("CutomerID", customerID);
            writer.WriteElementString("SalesRep", salesRep);
            writer.WriteElementString("Sales", sales.ToString());

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
             
            CumulativeSales += sales;
        }
    }
}
