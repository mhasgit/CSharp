using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsAndClasses
{
    internal class Customer1
    {
        /// <summary>
        /// Cutomer ID value
        /// </summary>
        public string CutomerID = null;

        /// <summary>
        /// Retrieve customer ID
        /// </summary>
        public void DisplayID()
        {
            Console.WriteLine(this.CutomerID);
        }

        /// <summary>
        /// Retrieve a customerID and a prompt
        /// </summary>
        /// <param name="Text">Prompt to prefix the customerID</param>
        public void DisplayID(string Text)
        {
            Console.WriteLine(Text + ": " + this.CutomerID);
        }
    }
}
