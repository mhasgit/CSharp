using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Writer1
    {
        //Start out with room for 4 entries
        private int currentSize = 4;

        private int writerCount = 0;

        private Writer[] Writers;

        public Writer1()
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

        public int Length
        {
            get { return writerCount; }
        }
    }
}
