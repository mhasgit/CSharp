using System.Xml;

namespace BCL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RandomNumbers();

            //EnvironmentClass();

            //WriteAndRead();

            //FileIO();

            FileInfoClass();

            //DirectoryInfoClass();

            //DriveInfoClass();
        }

        static void RandomNumbers()
        {
            Random randomNumber = new Random();

            Console.WriteLine("randomNumber = {0}", randomNumber.Next());
            Console.WriteLine("randomNumber = {0}", randomNumber.Next());
            Console.WriteLine("randomNumber = {0}", randomNumber.Next());

            Console.WriteLine("randomNumber = {0}", randomNumber.Next(100));

            Console.WriteLine("randomNumber = {0}", randomNumber.Next(50, 75));
        }

        static void EnvironmentClass()
        {
            Console.WriteLine("Machine name: {0}", Environment.MachineName);
            Console.WriteLine("User name: {0}", Environment.UserName);
            Console.WriteLine("OS version: {0}", Environment.OSVersion);
            Console.WriteLine("current directory: {0}", Environment.CurrentDirectory);
            Console.WriteLine("CLR version: {0}", Environment.Version);
            Console.WriteLine();

            FileInfo someFile = new FileInfo(@"c:\test.txt");
            someFile.CopyTo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\test.txt");
            Console.WriteLine("test.txt has been copied to the desktop");
        }

        static void WriteAndRead()
        {
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Indent = true;
            setting.NewLineChars = "\n\r";

            XmlWriter writer = XmlWriter.Create("c:\\test.xml", setting);

            writer.WriteStartDocument(true);
            writer.WriteStartElement("chapters");
            writer.WriteAttributeString("total", "2");
            writer.WriteElementString("chapter", "Data Types, And Variables");
            writer.WriteElementString("chapter", "Language Fundamentals");
            writer.WriteEndElement();

            writer.Close();

            XmlReader reader = XmlReader.Create("c:\\test.xml");

            //read xml one node at a time

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    Console.WriteLine(reader.Value);
                }
            }
            reader.Close();

            Console.WriteLine();

            reader = XmlReader.Create("c:\\test.xml");
            while (reader.ReadToFollowing("chapter"))
            {
                Console.WriteLine(reader.ReadInnerXml);
            }
            reader.Close();
        }

        static void FileIO()
        {
            StreamWriter newFile = new StreamWriter("c:\\test.txt");
            newFile.WriteLine("This is a line in the file.");
            newFile.WriteLine("This is another line in the file");
            newFile.Close();

            StreamReader existingFile = new StreamReader("c:\\test.txt");
            string nextLine;

            while ((nextLine = existingFile.ReadLine()) != null)
            {
                Console.WriteLine(nextLine);
            }
            existingFile.Close();
        }

        static void FileInfoClass()
        {
            //creat a file

            FileInfo someFile = new FileInfo("c:\\test.txt");

            if (!someFile.Exists)
            {
                FileStream someFileStream = someFile.Create();
                someFileStream.Close();
                someFile = new FileInfo("c:\\test.txt");
            }

            StreamWriter textToAdd;

            textToAdd = someFile.CreateText();
            textToAdd.WriteLine("This is a line in the file");
            textToAdd.Flush();
            textToAdd.Close();

            textToAdd = someFile.AppendText();
            textToAdd.WriteLine("This is another line in the file");
            textToAdd.Flush();
            textToAdd.Close();

            someFile = new FileInfo("c:\\test.txt");

            Console.WriteLine("File name: {0}", someFile.Name);
            Console.WriteLine("Full name: {0}", someFile.FullName);
            Console.WriteLine("Size: {0}", someFile.Length);
            Console.WriteLine();

            if (someFile.Exists)
            {
                someFile.CopyTo("c:\\test.txt2");
            }
            someFile.Delete();
        }

        static void DirectoryInfoClass()
        {
            DirectoryInfo demoDirectory = new DirectoryInfo(@"c:\AppDev demos");

            if (!demoDirectory.Exists)
            {
                demoDirectory.Create();

                Console.WriteLine(@"c:\AppDev demos has been created");
                Console.ReadKey();
            }

            FileInfo someFile = new FileInfo(@"c:\\test.txt");
            someFile.CopyTo(demoDirectory.FullName + @"test.txt");

            Console.WriteLine("test.text has been copied to AppDev demos");
            Console.ReadKey();

            demoDirectory.Delete(true);
            Console.WriteLine(@"c:\AppDev demos has been deleted");
        }

        static void DriveInfoClass()
        {
            DriveInfo Info = new DriveInfo("c:\\");

            Console.WriteLine("Drive name: {0}", Info.Name);
            Console.WriteLine("Drive type: {0}", Info.DriveType);

            if (Info.IsReady)
            {
                Console.WriteLine("Volume label: {0}", Info.VolumeLabel);
                Console.WriteLine("Drive format: {0}", Info.DriveFormat);
                Console.WriteLine("Total size: {0}", Info.TotalSize);
                Console.WriteLine("Available free space: {0:N0}", Info.AvailableFreeSpace);
                Console.WriteLine("Total free space: {0:N0}", Info.TotalFreeSpace / 1024 / 1024 / 1024);
            }
            else
            {
                Console.WriteLine("The drive is not ready");
            }
        }
    }
}