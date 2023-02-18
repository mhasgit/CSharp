using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class ComparerFileNames : IComparer
    {
        public int Compare(object x, object y)
        {
            FileInfo file1 = ((FileInfo)(x)); 
            FileInfo file2 = ((FileInfo)(y));

            return file1.FullName.CompareTo(file2.FullName);
        }
    }

    public class CompareFileLengths : IComparer
    {
        public int Compare(object x, object y)
        {
            FileInfo file1 = ((FileInfo)(x));
            FileInfo file2 = ((FileInfo)(y));

            return file1.Length.CompareTo(file2.Length);
        }
    }

    public class Comparers
    {
        public Comparers()
        {

        }
        public static int CompareFileNames(FileInfo file1, FileInfo file2)
        {
            return file1.FullName.CompareTo(file2.FullName);
        }

        public static int CompareFileLengths(FileInfo file1, FileInfo file2)
        {
            return file1.Length.CompareTo(file2.Length);
        }

        public static int CompareCustomerNames(Customer customer1, Customer customer2)
        {
            return customer1.CustomerName.CompareTo(customer2.CustomerName);
        }

    }
}
