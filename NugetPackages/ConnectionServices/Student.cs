namespace ConnectionServices
{
    public class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Student(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public void StudentDetails()
        {
            Console.WriteLine($"Hello {Name}, your age is {Age}");
        }
    }

    public class Teacher
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Teacher(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public void TeacherDetails()
        {
            Console.WriteLine($"Hello {Name}, your age is {Age}");
        }
    }
}