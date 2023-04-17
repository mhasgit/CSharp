using System.IO;

namespace InputOutputTools
{
    public interface IBinarySerializable
    {
        void Read(BinaryReader reader);

        void Write(BinaryWriter writer);
    }
}