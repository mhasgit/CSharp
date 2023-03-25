using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputOutputStreams
{
    namespace InputOutputStreams
    {
        using System;

        public class MyCon
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

}
