﻿namespace InputOutputStreams
{
    using System;
    using System.IO;

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
