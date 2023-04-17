using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InputOutputTools
{
    public class BinaryFileViewer
    {
        public static void ViewFile(string fileName)
        {
			try
			{
				using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
				{
					long length = fileStream.Length;
					byte[] buffer = new byte[length];

					int bytesRead = fileStream.Read(buffer, 0, buffer.Length);

					Console.WriteLine("File size: {0} bytes\n", buffer.Length);

					for (int i = 0; i < length; i += 16)
					{
						Console.WriteLine("{0:X8}: ", i);

						for (int j = 0; j < 16; j++)
						{
							if (i + j < length)
							{
								Console.WriteLine("{0:X2} ", buffer[i + j]);
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
