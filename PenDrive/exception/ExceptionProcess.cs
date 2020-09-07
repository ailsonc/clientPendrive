using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenDrive.exception
{
    class ExceptionProcess : Exception
    {
        public ExceptionProcess()
        {
        }
        public ExceptionProcess(string message)
            : base(message)
        {
        }
        public ExceptionProcess(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
