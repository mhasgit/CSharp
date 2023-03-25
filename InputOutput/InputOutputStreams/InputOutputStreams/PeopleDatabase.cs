using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace InputOutputStreams
{
    internal class PeopleDatabase : IDisposable
    {
        // Track whether Dispose has been called.
        private bool disposed = false;
        private readonly FileStream fileStream;
        //private readonly List<int> indexes = new List<int>();
        private readonly Dictionary<int, long> index;

        public PeopleDatabase(string dbFileName)
        {
            this.fileStream = File.Open(dbFileName, FileMode.OpenOrCreate);
            this.index = new Dictionary<int, long>();
        }

        public Person3 Get(int id)
        {
            long position = index[id];
            fileStream.Seek(position, SeekOrigin.Begin);

            // Read the size of the object first
            BinaryReader reader = new BinaryReader(fileStream);
            int recordSize = reader.ReadInt32();
            byte[] recordBuffer = new byte[recordSize];
            int bytesRead = reader.Read(recordBuffer, 0, recordSize);

            if (bytesRead != recordSize)
            {
                throw new Exception("File corrupted");
            }

            MemoryStream stream = new MemoryStream(recordBuffer);
            IFormatter formatter = new BinaryFormatter();

            Person3 person;
            try
            {
                person = (Person3)formatter.Deserialize(stream);
            }
            catch (Exception)
            {

                throw;
            }

            return person;
        }

        public int Insert(Person3 person)
        {
            if (person == null) throw new ArgumentNullException();
            // if (person.Id < 0) throw new ArgumentOutOfRangeException();
            // new ObjectIDGenerator().GetId
            // index.Add(person.Id, dbFileStream.Position);
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, person);

            BinaryWriter writer = new BinaryWriter(fileStream);
            writer.Write(stream.Length);
            writer.Write(stream.ToArray());

            throw new NotImplementedException();
        }

        public int Update(Person3 person)
        {
            throw new NotImplementedException();
        }

        public int Delete(Person3 person)
        {
            throw new NotImplementedException();
        }

        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(disposing: true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SuppressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    fileStream.Dispose();
                }

                // Note disposing has been done.
                disposed = true;
            }
        }

        // Use C# finalizer syntax for finalization code.
        // This finalizer will run only if the Dispose method
        // does not get called.
        // It gives your base class the opportunity to finalize.
        // Do not provide finalizer in types derived from this class.
        ~PeopleDatabase()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(disposing: false) is optimal in terms of
            // readability and maintainability.
            Dispose(disposing: false);
        }
    }
}
