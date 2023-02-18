using parenthesisProblem;
using System.IO.Pipes;

namespace ParenthesisProblem.Tests
{
    public class StackTests
    {
        [Fact]
        public void Test1()
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
        }

        [Fact]
        public void TestTwo()
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < stack.Size(); i++)
            {
                stack.Push(i);
            }

            for (int i = stack.Size() - 1; i >= 0; i--)
            {
                Assert.Equal(i, stack.Pop());
            }
        }
    }
}