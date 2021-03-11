using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Exceptions
{
    class CompilerException : Exception
    {
        private string status = "Compile Failed";
        public string exceptionMessage { get; }

        public override string Message
        {
            get
            {
                return string.Format("{0}\n{1}", status, exceptionMessage);
            }
        }

        public CompilerException(string message)
        {
            this.exceptionMessage = message;
        }
    }
}
