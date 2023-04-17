using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputOutputTools.BinarySerializer
{
    public interface IBinarySerializable
    {
        void Read(BinaryReader reader);

        void Write(BinaryWriter writer);
    }
}
