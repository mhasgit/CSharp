﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StreamPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Student student = new Student();

            Console.Write("Enter student name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter father name: ");
            student.FatherName = Console.ReadLine();

            student.Age = random.Next(0, 20);

            Console.Write("Enter Address: ");
            student.Address = Console.ReadLine();

            string path = @"C:\Student.txt";

            using (StreamWriter sw = File.CreateText(path))
            {
                student.WriteStudent(sw);
                //sw.WriteLine(student.Name);
                //sw.WriteLine(student.FatherName);
                //sw.WriteLine(student.Age);
                //sw.WriteLine(student.Address);
            }

            using (StreamReader sr = File.OpenText(path))
            {
                Console.WriteLine(sr.ReadToEnd());
                
            }
        }
        
        //static void WorkingWithBinaryClass()
        //{
        //    BinaryReader br = new BinaryReader(@"D:\\Poem.txt");
        //}

        static void WrokingWithDirectoryInfoClass()
        {
            DirectoryInfo di = new DirectoryInfo(@"D:\New folder");
            DirectoryInfo[] demo = di.GetDirectories();


            Console.WriteLine("Fullname: {0}", di.FullName);
            Console.WriteLine("Attributes: {0}", di.Attributes);

            foreach (DirectoryInfo item in demo)
            {
                Console.WriteLine(item.FullName);
            }
            foreach (var demo1 in di.GetFiles())
            {
                Console.WriteLine(demo1.Name);
            }
            if (di.Exists)
            {
                di.Create();
            }
        }

        static void WorkingWithDriveInfoClass()
        {
            DriveInfo[] AllDrive = DriveInfo.GetDrives();

            foreach (var item in AllDrive)
            {
                if (item.IsReady == true)
                {
                    Console.WriteLine(item.RootDirectory);
                }
            }
        }

        static void WorkingWithFileClass()
        {
            string path = @"D:\Demo\Mytext.txt";

            if (!File.Exists(path))
            {
               using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Hello!");
                    sw.WriteLine("World");
                }
            }

            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }

        

    }
}
