using System;

namespace parenthesisProblem
{
    public class Stack<T>
    {
        const int Maxsize = 10;
        private int top = -1;
        private int size;
        private T[] stack;


        public Stack()
        {
            this.size = Maxsize;
            this.stack = new T[this.size];
        }

        public Stack(int size)
        {
            this.size = size;
            this.stack = new T[this.size];
        }

        public void Push(T data)
        {
            if (top == this.size)
            {
                throw new Exception("overflow");
            }
            else
            {
                stack[++top] = data;
            }

        }

        public T Pop()
        {
            if (top < 0)
            {
                throw new Exception("underflow");
            }
            else
            {
                return stack[top--];
            }
        }

        public T Peek()
        {
            return stack[top];
        }

        public int Size()
        {
            return this.size;
        }
    }
}