using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PredefinedInterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person()
            {
                Id = 1,
                Name = "Test",
                Age = 20
            };

            // Type person = typeof(Person);

            string json = JsonConvert.SerializeObject(p);
            Console.WriteLine(json);


            Person p2 = JsonConvert.DeserializeObject<Person>(json);
            Console.WriteLine(p.Id == p2.Id);
            Console.WriteLine(p.Name == p2.Name);
            Console.WriteLine(p.Age == p2.Age);

            Console.ReadLine();
        }

        void XmlSerializerBasics(Person p)
        {
            string personXml = SerializePerson(p);
            Console.WriteLine(personXml);


            Person p2 = DeserializePerson(personXml);
            Console.WriteLine(p.Id == p2.Id);
            Console.WriteLine(p.Name == p2.Name);
            Console.WriteLine(p.Age == p2.Age);
        }


        static string SerializePerson(Person p)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, p);
            return writer.ToString();
        }

        static Person DeserializePerson(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            StringReader reader = new StringReader(xml);
            Person p = (Person)serializer.Deserialize(reader);
            return p;
        }

        void InterfacesBasics()
        {
            using (FileStream fs = new FileStream("somefile", FileMode.CreateNew))
            {

            }

            //using(Person p = new Person())
            //{
            //}

            List<int> numbers = new List<int>
            {
                1,
                2,
                3,
                4
            };

            foreach (int i in numbers)
            {

            }

            List<int>.Enumerator enumerator = numbers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var number = enumerator.Current;
            }



            People people = new People();
            foreach (var p in people) // forward only and read only
            {
                // p = new Person();
            }


            for (int i = 0; i < numbers.Count; i++)
            {
                ICollection<int> numbersCol = numbers;
                numbers.Add(i);
                numbers[0] = 123;
            }
        }
    }

    [XmlRoot("Person")]
    public class Person
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Age")]
        public int Age { get; set; }
    }



    public class People : IEnumerable<Person>
    {
        public IEnumerator<Person> GetEnumerator()
        {
            // return new PersonEnumerator();
            yield return new Person();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class PersonEnumerator : IEnumerator<Person>
    {
        public Person Current { get; set; }

        public bool MoveNext()
        {
            this.Current = new Person();
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
