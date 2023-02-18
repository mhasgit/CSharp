using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class CompareFiles : System.Collections.IComparer
    {
        public enum CompareFields
        {
            Name,
            Length
        };

        //Determine how to sort the data
        public CompareFields CompareOn = CompareFields.Name;

        //Set the comparison, as you create the 
        //instance of this class

        public CompareFiles(CompareFields CompareOn)
        {
            this.CompareOn = CompareOn;
        }

        public int Compare(object x, object y)
        {
            FileInfo file1 = (FileInfo)x;
            FileInfo file2 = (FileInfo)y;
            int result = 0;

            switch (CompareOn)
            {
                case CompareFields.Name:
                    result = file1.FullName.CompareTo(file2.FullName);
                    break;
                case CompareFields.Length:
                    result = file1.Length.CompareTo(file2.Length);
                    //If the sizes are the same, use the same for sorting
                    if (result == 0)
                    {
                        result = file1.FullName.CompareTo(file2.FullName);
                    }
                    break;
            }
            return result;
        }
    }
}
