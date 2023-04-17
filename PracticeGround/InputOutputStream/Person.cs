using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InputOutputStream
{
    public class Person
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public void Read(BinaryReader reader)
        {
            this.Age = reader.ReadInt32();
            this.Name = reader.ReadString();
            int year = reader.ReadInt32();
            int month = reader.ReadInt32();
            int day = reader.ReadInt32();
            this.DateOfBirth = new DateTime(year, month, day);
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(this.Age);
            writer.Write(this.Name);
            writer.Write(this.DateOfBirth.Year);
            writer.Write(this.DateOfBirth.Month);
            writer.Write(this.DateOfBirth.Day);
        }

        public void WritePerson(StreamWriter streamWriter)
        {
            streamWriter.Write(this.Age);
            streamWriter.Write('|');
            streamWriter.Write(this.Name);
            streamWriter.Write('|');
            streamWriter.Write(this.DateOfBirth);
        }

        public void ReadPerson(StreamReader streamReader)
        {
            string line = Console.ReadLine();

            if (string.IsNullOrEmpty(line))
            {
                return;
            }

            string[] personData = line.Split('|');
            this.Age = int.Parse(personData[0]);
            this.Name = personData[1];
            this.DateOfBirth = DateTime.Parse(personData[2]);
        }
    }
}
