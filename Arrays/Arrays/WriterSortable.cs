using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class WriterSortable : Writer, IComparable
    {

        public WriterSortable()
        {

        }

        public WriterSortable(string Name, string HomeState) : base(Name, HomeState)
        {
            //Call the base class' non-default constructor
        }

        public int CompareTo(object obj)
        {
            WriterSortable otherwriter = (WriterSortable)obj;
            return this.Name.CompareTo(otherwriter.Name);
        }
    }
}
