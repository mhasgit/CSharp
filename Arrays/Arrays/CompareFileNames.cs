using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class CompareFileNames : IComparer
    {

        public int Compare(object x, object y)
        {
            FileInfo file1 = (FileInfo)x;
            FileInfo file2 = (FileInfo)y;

            return file1.Name.CompareTo(file2.Name);
        }
    }
}
