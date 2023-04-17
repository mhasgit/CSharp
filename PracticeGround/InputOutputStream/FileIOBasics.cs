using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputOutputStream
{
    public class FileIOBasics
    {
        static void Main2(string[] strings)
        {
            Person person = new Person()
            {
                Age = 38,
                Name = "Ali",
                DateOfBirth = DateTime.Now.AddYears(-38)
            };

            Person[] people = new Person[]
            {
                person,
                new Person()
                {
                    Age = 24,
                    Name = "Riaz",
                    DateOfBirth = DateTime.Now.AddYears(-24)
                }
            };

            string filePath = "../..people.txt";

            using (FileStream fs = File.OpenWrite(filePath))
            using (StreamWriter streamWriter = new StreamWriter(fs))
            {
                foreach (var p in people)
                {
                    p.WritePerson(streamWriter);
                }
            }

            Console.WriteLine("people written to file..\nPress enter to read from file");
            Console.ReadKey();

            Person[] peopleFromFile = new Person[people.Length];
            for (int i = 0; i < peopleFromFile.Length; i++)
            {
                peopleFromFile[i] = new Person();
            }

            using (FileStream fs = File.OpenRead(filePath))
            using (StreamReader streamReader = new StreamReader(fs))
            {
                foreach (var p in peopleFromFile)
                {
                    p.ReadPerson(streamReader);
                }
            }

            foreach (var p in peopleFromFile)
            {
                Console.Write(p.Age);
                Console.Write(" ");
                Console.Write(p.Name);
                Console.Write(" ");
                Console.Write(p.DateOfBirth);
            }
        }

        void PeopleFileStream()
        {

        }
    }
}
