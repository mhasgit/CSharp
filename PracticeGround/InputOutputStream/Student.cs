using InputOutputTools.BinarySerializer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InputOutputStream
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
