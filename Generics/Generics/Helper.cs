using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Helper
    {
        public static void Swap(ref int item1, ref int item2)
        {
            int temp = 0;
            temp = item1;
            item1 = item2;
            item2 = temp;
        }

        public static void Swap(ref string item1, ref string item2)
        {
            string temp = null;
            temp = item1;
            item1 = item2;
            item2 = temp;
        }

        public static void Swap(ref object item1, ref object item2)
        {
            object temp = null;

            if (item1 is int)
            {
                temp = Convert.ToInt32(item1);
                item1 = Convert.ToInt32(item2);
                item2 = Convert.ToInt32(temp);
                return;
            }
            if (item1 is string)
            {
                temp = Convert.ToString(item1);
                item1 = Convert.ToString(item2);
                item2 = Convert.ToString(temp);
                return;
            }
        }
    }

    public class Helper2
    {
        public static void Swap<T>(ref T item1, ref T item2)
        {
            T temp;
            temp = item1;
            item1 = item2;
            item2 = temp;
        }

        public static string MakeString<T>(T item1, T item2)
        {
            return item1.ToString() + item2.ToString();
        }
    }

    public class Helper3<T>
    {
        public static void Swap(ref T item1, ref T item2)
        {
            T temp;
            temp = item1;
            item1 = item2;
            item2 = temp;
        }

        public static string MakeString(T item1, T item2)
        {
            return item1.ToString() + item2.ToString();
        }
    }
}
