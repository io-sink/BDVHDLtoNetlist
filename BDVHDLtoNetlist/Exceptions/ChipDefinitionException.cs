using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Exceptions
{
    class ChipDefinitionException : Exception
    {
        private string status = "Chip Definition Error";
        public string designFile { get; }
        public string exceptionMessage { get; }

        public override string Message
        {
            get
            {
                return string.Format("{0} : {1}\n{2}", designFile, status, exceptionMessage);
            }
        }

        public ChipDefinitionException(string designFile, string message)
        {
            this.designFile = designFile;
            this.exceptionMessage = message;
        }
    }
}
