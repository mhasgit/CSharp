using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JsonAndXmlPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ReadCountriesData();

             JsonToXmlConvertor();

            // XmlToJsonConvertor();

        }

        private static void XmlToJsonConvertor()
        {
            string xmlFilePath = $"C:/C#/PredefinedInterfaces/JsonAndXmlPractice/CountriesXml.txt";
            string jsonFilePath = $"C:/C#/PredefinedInterfaces/JsonAndXmlPractice/CountriesJson.txt";

            string xmlData = File.ReadAllText(xmlFilePath);


            XDocument xdoc = XDocument.Parse(xmlData);

            JObject jsonObj = JObject.Parse(JsonConvert.SerializeXNode(xdoc));

            if (jsonObj["@xmlns"] != null)
            {
                jsonObj.Property("@xmlns").Remove();
            }

            File.WriteAllText(jsonFilePath, jsonObj.ToString());

            Console.WriteLine("Xml data has been converted to Json and saved");
        }

        private static void JsonToXmlConvertor()
        {
            string jsonFilePath = $"C:/C#/PredefinedInterfaces/JsonAndXmlPractice/countriesData.txt";
            string xmlFilePath = $"C:/C#/PredefinedInterfaces/JsonAndXmlPractice/CountriesXml.txt";

            string jsonData = File.ReadAllText(jsonFilePath);

            List<CountriesParser> countries = JsonConvert.DeserializeObject<List<CountriesParser>>(jsonData);

            string xmlData = JsonConvert.DeserializeXmlNode("{\"Country\":" + jsonData + "}", "Countries").OuterXml;

            File.WriteAllText(xmlFilePath, xmlData);

            Console.WriteLine("JSON data has been converted to XML and saved");
        }

        private static void ReadCountriesData()
        {
            string jsonFilePath = $"C:/C#/PredefinedInterfaces/JsonAndXmlPractice/countriesData.txt";

            string jsonData = File.ReadAllText(jsonFilePath);

            List<CountriesParser> countries = JsonConvert.DeserializeObject<List<CountriesParser>>(jsonData);

            foreach (var country in countries)
            {
                Console.WriteLine($"ID: {country.id}, Alpha2: {country.alpha2}, Alpha3: {country.alpha3}, Name: {country.arabicName}");
            }
        }
    }
}
