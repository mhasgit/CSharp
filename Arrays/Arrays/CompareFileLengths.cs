using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class CompareFileLengths : IComparer
    {
        public int Compare(object x, object y)
        {
            FileInfo file1 = (FileInfo)x;
            FileInfo file2 = (FileInfo)y;

            //If the sizes are same, use the name for sorting
            int result = file1.Length.CompareTo(file2.Length);

            if (result == 0)
            {
                //File lenghts the same? Return the name comparison instead:
                result = file1.FullName.CompareTo(file2.FullName);
            }

            return result;
        }
    }
}
