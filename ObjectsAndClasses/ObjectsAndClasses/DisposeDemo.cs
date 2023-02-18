using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsAndClasses
{
    internal class DisposeDemo : IDisposable
    {
        private System.IO.FileStream fs = null;

        private bool alreadyDispose = false;

        public void Dispose()
        {
            if (!alreadyDispose)
            {
                if (fs != null)
                    fs.Close(); 
                    Console.WriteLine("In Dispose");             
            }
            this.alreadyDispose = true;
            GC.SuppressFinalize(this);
        }

        
    }
}
