namespace InputOutputTools
{
    using System;
    using System.IO;

    public class BinaryFileViewer
    {
        public static void ViewFile(string filename)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    long length = fileStream.Length;
                    byte[] buffer = new byte[length];

                    int bytesRead = fileStream.Read(buffer, 0, buffer.Length);

                    Console.WriteLine("File size: {0} bytes\n", length);

                    for (int i = 0; i < length; i += 16)
                    {
                        Console.Write("{0:X8}: ", i);

                        for (int j = 0; j < 16; j++)
                        {
                            if (i + j < length)
                            {
                                Console.Write("{0:X2} ", buffer[i + j]);
                            }
                            else
                            {
                                Console.Write("   ");
                            }
                        }

                        Console.Write(" ");

                        for (int j = 0; j < 16 && i + j < length; j++)
                        {
                            byte b = buffer[i + j];
                            char c = (b >= 32 && b <= 126) ? (char)b : '.';
                            Console.Write(c);
                        }

                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: {0}", ex.Message);
            }
        }
    }
}
