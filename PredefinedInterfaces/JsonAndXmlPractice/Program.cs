using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JsonAndXmlPractice
{

    public class Country
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("alpha2")]
        public string Alpha2 { get; set; }

        [JsonProperty("alpha3")]
        public string Alpha3 { get; set; }

        [JsonProperty("name")]
        public string CountryName { get; set; }
    }

    public class CountriesService
    {
        public List<Country> GetCountriesByLocale(string locale = "en", string contentType = "json")
        {
            var responseText = this.GetCountriesText(locale, contentType);

            List<Country> countries = null;
            if (contentType == "json")
            {
                countries = JsonConvert.DeserializeObject<List<Country>>(responseText);
            }
            else if (contentType == "xml")
            {
                // 
            }
            else if (contentType == "csv")
            {

            }
            else if (contentType == "sql")
            {
                //SqlConnection con = new SqlConnection("");
                //SqlCommand command = con.CreateCommand();
                //command.CommandText = responseText.ToString();
                //command.BeginExecuteNonQuery();
                // SqlConnection
                // SqlCommand
                // SqlDataReader, 
            }

            return countries;
        }

        private string GetCountriesText(string locale, string contentType)
        {
            string countriesJsonUrl = $"https://raw.githubusercontent.com/stefangabos/world_countries/master/data/countries/{locale}/countries.{contentType}";

            HttpWebRequest request = WebRequest.CreateHttp(countriesJsonUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string jsonResponse = reader.ReadToEnd();

            return jsonResponse;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            string locale = GetSupportedLocaleFromUser();

            CountriesService countriesService = new CountriesService();
            List<Country> countries = countriesService.GetCountriesByLocale(locale);

            // ReadCountriesData();

            // JsonToXmlConvertor();

            // XmlToJsonConvertor();

        }

        private static string GetSupportedLocaleFromUser()
        {
            string[] supportedLocales = new[] { "en", "ar", "fr", "de" };

            string locale = string.Empty;
            do
            {
                Console.Write("Enter a locale option (en, ar, fr, de): ");
                locale = Console.ReadLine();
            }
            while (!supportedLocales.Contains(locale.Trim()));

            return locale;
        }

        void BasicHttpRequestResponse()
        {
            string locale = GetSupportedLocaleFromUser();

            string countriesJsonUrl = $"https://raw.githubusercontent.com/stefangabos/world_countries/master/data/countries/{locale}/countries.json";

            HttpWebRequest request = WebRequest.CreateHttp(countriesJsonUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string jsonResponse = reader.ReadToEnd();
            Console.WriteLine(jsonResponse);

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
