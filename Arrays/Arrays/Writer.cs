using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Writer : Writer1
    {
        public string Name = string.Empty;
        public string HomeState = string.Empty;

        public Writer()
        {
            //Many feature in the .NetFramfork require
            //a default constructor
        }

        public Writer(string Name, string HomeState)
        {
            this.Name = Name;
            this.HomeState = HomeState;
        }

        public override string ToString()
        {
            return String.Format("{0} is from {1}", this.Name, this.HomeState);
        }
    }
}
