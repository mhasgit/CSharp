namespace InputOutputStreams
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class Person3 : ISerializable
    {
        public Person3() { }

        public int Age { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        // The special constructor is used to deserialize values.
        public Person3(SerializationInfo info, StreamingContext context)
        {
            // Reset the property value using the GetValue method.
            Age = info.GetInt32("Age");
            Name = info.GetString("Name");
            DateOfBirth = info.GetDateTime("DateOfBirth");
        }

        // Special
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Age", Age);
            info.AddValue("Name", Name);
            info.AddValue("DateOfBirth", DateOfBirth);
        }
    }
}
