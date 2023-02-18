namespace InputOutputStreams
{
    using System;
    using System.CodeDom;
    using System.Data.SqlClient;
    using System.IO;

    public class Program
    {
        static void Main(string[] args)
        {
            // Byte-oriented IO
            // Character-oriented IO

            Stream stream = null;
            FileStream fileStream = null;
            MemoryStream memoryStream = new MemoryStream();
            BufferedStream bufferedStream = null;

            byte[] memoryBuffer = new byte[1024];
            MemoryStream mStream = new MemoryStream();

            TextReader textReader = null;

            StreamReader streamReader = null;
            StreamWriter streamWriter = null;

            StringReader reader;
            StringWriter writer;
        }
    }

    public class ByteArrayStream : MemoryStream
    {
        public ByteArrayStream() : base() { }

        public ByteArrayStream(byte[] buffer) : base(buffer) { }
    }
}
