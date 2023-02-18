using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Writer3 : System.Collections.IEnumerable
    {
        //Start out with room for 4 entries
        private int currentSize = 4;

        private int writerCount = 0;

        private Writer[] Writers;

        public Writer3()
        {
            Writers = new Writer[currentSize];
        }

        public void Add(Writer newWriter)
        {
            //Insert a new writer, making sure
            //the array is large enough, You don't
            //want to resize to often--It's slow
            if (writerCount >= Writers.Length)
            {
                currentSize *= 2;

                //Reset the size of the array
                Writer[] temp = (Writer[])Writers.Clone();
                Writers = new Writer[currentSize];
                Array.Copy(temp, Writers, temp.Length);
                temp = null;
            }
            //Insert the new writer
            Writers[writerCount++] = newWriter;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Writer item in Writers)
            {
                yield return item;
            }
        }

        public int Length
        {
            get { return writerCount; }
        }

        public Writer this[int index]
        {
            get
            {
                if (index > 0 || index >= Writers.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return Writers[index];
            }
            set
            {
                if (index < 0 || index >= writerCount)
                {
                    //Only allow adding writers
                    //by calling Add method
                    throw new IndexOutOfRangeException();
                }
                Writers[index] = value;
            }
        }

        public Writer this[string writerName]
        {
            
            get
            {
                //There are better ways to find an
                //item in an array, but this is simplest:
                foreach (Writer item in Writers)
                {
                    if (item.Name == writerName)
                    {
                        return item;
                    }
                    throw new IndexOutOfRangeException("Unknown writer name");
                }
            }
            set
            {
                for (int i = 0; i < writerCount; i++)
                {
                    if (Writers[i].Name == writerName)
                    {
                        Writers[i] = value;
                        //Only work with the first match
                        return;
                    }
                }
                //If you get here you did'nt find a match
                throw new IndexOutOfRangeException("Unknown writer name");
            }
        }

    }
}
