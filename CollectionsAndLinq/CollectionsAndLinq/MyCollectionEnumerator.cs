using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsAndLinq
{
    class MyCollectionEnumerator<T> : IEnumerator<T>
    {
        int currentIndex = 0;
        T[] array;

        public MyCollectionEnumerator(T[] array)
        {

            this.array = array;

        }

        public T Current
        {
            get
            {
                return this.array[currentIndex++];
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (currentIndex < array.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            currentIndex = 0;
        }

        object IEnumerator.Current => throw new NotImplementedException();
    }
}
