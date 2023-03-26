using InputOutputTools;
using System.IO;

namespace InputOutputStreams
{
    public class Student : IBinarySerializable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public void Read(BinaryReader reader)
        {
            this.Id = reader.ReadInt32();
            this.Name = reader.ReadString();
            this.Address = reader.ReadString();
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(Id);
            writer.Write(Name);
            writer.Write(Address);
        }
    }
}
