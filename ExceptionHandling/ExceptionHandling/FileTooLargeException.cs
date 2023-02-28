using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class FileTooLargeException : ApplicationException
    {
        private long _fileSize;

        public FileTooLargeException(string Message, Exception Inner, long FileSize) : base(Message, Inner)
        {
            _fileSize = FileSize;
        }

        public long FileSize
        {
            get
            {
                return _fileSize;
            }
        }
    }
}
