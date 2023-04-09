using System.Collections;
using System.Collections.Generic;

namespace CollectionsAndLinq
{
    class TestMyCollection
    {
        void Test()
        {
            MyCollection<int> collection = new MyCollection<int>();
            // collection.MyAll
        }
    }
    class MyCollection<T> : IEnumerable<T>, IEnumerable
    {
        T[] array = new T[10];

        public void Initilize(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                this.array[i] = array[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            //foreach (T item in array)
            //{
            //    yield return item;
            //}

            return new MyCollectionEnumerator<T>(array);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyCollectionEnumerator<T>(array);
        }
    }
}
