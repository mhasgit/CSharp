using System.IO;

namespace InputOutputTools
{
    public class FileSerializer<T> where T : IBinarySerializable, new()
    {
        private readonly string fileName;

        public FileSerializer(string fileName)
        {
            this.fileName = fileName;
        }

        public void WriteObject(T entity)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(this.fileName, FileMode.Create)))
            {
                entity.Write(writer);
            }
        }

        public T ReadObject()
        {
            T entity = new T();
            
            using (BinaryReader reader = new BinaryReader(File.Open(this.fileName, FileMode.Open)))
            {
                entity.Read(reader);
            }

            return entity;
        }

        public void WriteObjects(T[] entities)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(this.fileName, FileMode.Create)))
            {
                foreach (var entity in entities)
                {
                    entity.Write(writer);
                }
            }
        }

        public T[] ReadObjects(int size)
        {
            T[] entities = new T[size];

            using (BinaryReader reader = new BinaryReader(File.Open(this.fileName, FileMode.Open)))
            {
                int i = 0;
                foreach (var entity in entities)
                {
                    entities[i] = new T();
                    entity.Read(reader);
                }
            }

            return entities;
        }
    }
}
