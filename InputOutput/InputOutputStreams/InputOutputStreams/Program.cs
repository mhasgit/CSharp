namespace InputOutputStreams
{
    using System;
    using System.CodeDom;
    using System.Data.SqlClient;
    using System.IO;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization.Formatters.Soap;


    public class Con
    {
        /// <summary>
        /// Reads the next character from the standard input stream.
        /// </summary>
        /// <returns>character read from Console.Read</returns>
        public static char ReadChar()
        {
            return (char)Console.Read();
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {

            Person person = new Person()
            {
                Age = 21,
                Name = "Jimmy John",
                DateOfBirth = DateTime.Now.AddYears(-21)
            };

            Person[] people = new Person[] 
            {
                person,
                new Person
                {
                    Age= 31,
                    Name = "Jane Doe",
                    DateOfBirth= DateTime.Now.AddYears(-31)
                }
            };


            string filePath = "../../people.txt";
            using (FileStream fs = File.OpenWrite(filePath))
            using (StreamWriter streamWriter = new StreamWriter(fs))
            {
                foreach (var p in people)
                {
                    p.WritePerson(streamWriter);
                }
            }

            Console.WriteLine("People written to file...\nPress enter to read people from file");
            Console.ReadLine();

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
                Console.WriteLine(p.Name);
                Console.Write(" ");
                Console.WriteLine(p.DateOfBirth);
            }










            //while (true)
            //{
            //    char c = Con.ReadChar();
            //    switch (c)
            //    {
            //        case '1':
            //            Console.WriteLine("asdasd");
            //            break;

            //        default:
            //            Console.WriteLine("asdasd");
            //            break;
            //    }
            //}


            // Console IO redirection
        }


        void PeopleFileStream()
        {
            string fileName = "people.dat";
            FileStream dataOutputStream = File.OpenWrite(fileName);

            Person person = new Person()
            {
                Age = 21,
                Name = "Jimmy John",
                DateOfBirth = DateTime.Now.AddYears(-21)
            };
            Person[] people = new Person[] {
                person,
                new Person
                {
                    Age= 31,
                    Name = "Jane Doe",
                    DateOfBirth= DateTime.Now.AddYears(-31)
                }
            };

            MemoryStream byteArrayOutputStream = new MemoryStream();

            // Use a BinaryFormatter or SoapFormatter.
            // IFormatter formatter = new BinaryFormatter();
            IFormatter formatter = new SoapFormatter();
            formatter.Serialize(byteArrayOutputStream, people);
            dataOutputStream.Close();


            FileStream dataInputStream = File.OpenRead(fileName);
            MemoryStream byteArrayInputStream = new MemoryStream(byteArrayOutputStream.ToArray());
            Person[] deserializedPerson = (Person[])formatter.Deserialize(byteArrayInputStream);
            dataInputStream.Close();

            foreach (var p in deserializedPerson)
            {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine("Plress enter to close");
            Console.ReadLine();
        }

        public void StreamBasics()
        {
            /*******************************************/

            // Byte-oriented IO
            // Character-oriented IO

            // Stream stream = null; 
            // FileStream stream1 = null;
            // MemoryStream stream2 = new MemoryStream();

            // BufferedStream bufferedStream = null;

            // byte[] memoryBuffer = new byte[1024];
            // MemoryStream mStream = new MemoryStream();

            // TextReader textReader = null;
            // TextWriter textWriter = null;

            // StreamReader streamReader = new StreamReader();
            // StreamWriter streamWriter = null;
            // StringWriter writer = new StringWriter();
        }
    }

    public class ByteArrayStream : MemoryStream
    {
        public ByteArrayStream() : base() { }

        public ByteArrayStream(byte[] buffer) : base(buffer) { }
    }


    [Serializable]
    public class Person
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }


        public void WritePerson(StreamWriter streamWriter)
        {
            streamWriter.Write(this.Age);
            streamWriter.Write('|');
            streamWriter.Write(this.Name);
            streamWriter.Write("|");
            streamWriter.WriteLine(this.DateOfBirth); // .ToString("dd/MM/yyyy"))
        }

        public void ReadPerson(StreamReader streamReader)
        {
            string line = streamReader.ReadLine();
            if (string.IsNullOrEmpty(line))
            {
                return;
            }

            // 21|Jimmy John|20/12/1994
            string[] personData = line.Split('|');
            this.Age = int.Parse(personData[0]);
            this.Name = personData[1];
            this.DateOfBirth = DateTime.Parse(personData[2]);
        }
    }



    //[Serializable]
    //public class Person : ISerializable
    //{
    //    public Person() { }

    //    // The special constructor is used to deserialize values.
    //    public Person(SerializationInfo info, StreamingContext context)
    //    {
    //        // Reset the property value using the GetValue method.
    //        Age = info.GetInt32("Age");
    //        Name = info.GetString("Name");
    //        DateOfBirth = info.GetDateTime("DateOfBirth");
    //    }

    //    public int Age { get; set; }

    //    public string Name { get; set; }

    //    public DateTime DateOfBirth { get; set; }

    //    // Special
    //    public void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        info.AddValue("Age", Age);
    //        info.AddValue("Name", Name);
    //        info.AddValue("DateOfBirth", DateOfBirth);
    //    }
    //}
}
