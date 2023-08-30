using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JsonAndXmlPractice
{
    public class CountriesParser
    {
        public int id { get; set; }
        public string alpha2 { get; set; }
        public string alpha3 { get; set; }
        public string arabicName { get; set; }
    }

    
    
}
