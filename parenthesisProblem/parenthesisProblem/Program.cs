namespace parenthesisProblem
{
    using System;
    using System.IO;

    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            FileStream fileStream = File.OpenRead(@"C:\AppDev demos\Stack.cs");

            StreamReader streamReader = new StreamReader(fileStream);

            while (!streamReader.EndOfStream)
            {
                char ch = (char)streamReader.Read();
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    stack.Push(ch);
                }
                else if (ch == ')' || ch == ']' || ch == '}')
                {
                   char openBracket = stack.Pop();
                    if (openBracket == '(' && ch != ')')
                    {
                        Console.WriteLine("Parenthesis did not match");
                        break;
                    }
                    else if (openBracket == '[' && ch != ']')
                    {
                        Console.WriteLine("Square Brackets did not match");
                        break;
                    }
                    else if (openBracket == '{' && ch != '}')
                    {
                        Console.WriteLine("Braces did not match");
                        break;
                    }
                }
                
            }
            
            fileStream.Close();
            streamReader.Close();
        }
    }
}