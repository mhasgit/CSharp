using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamPractice
{
    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }

        public void WriteStudent(StreamWriter streamwriter)
        {
            streamwriter.Write(this.Name);
            streamwriter.Write("/");
            streamwriter.Write(this.FatherName);
            streamwriter.Write("/");
            streamwriter.Write(this.Age);
            streamwriter.Write("/");
            streamwriter.Write(this.Address);
        }

    }
}
