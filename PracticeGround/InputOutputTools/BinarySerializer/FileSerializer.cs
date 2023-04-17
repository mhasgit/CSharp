using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputOutputTools.BinarySerializer
{
    public class FileSerializer<T> where T : IBinarySerializable, new()
    {
        private readonly string FileName;

        public FileSerializer(string fileName)
        {
            this.FileName = fileName;
        }

        public void WriteObject(T entity)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open)))
            {
                entity.Write(writer);
            }
        }

        public T ReadObject()
        {
            T entity = new T();

            using (BinaryReader reader = new BinaryReader(File.Open(this.FileName, FileMode.Create)))
            {
                entity.Read(reader);
            }
            return entity;
        }

        public void WriteObjects(T[] entities)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(this.FileName, FileMode.Create)))
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

            using (BinaryReader reader = new BinaryReader(File.Open(this.FileName, FileMode.Create)))
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
