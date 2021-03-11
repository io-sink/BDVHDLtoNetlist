using Irony;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Exceptions
{
    class ParserException : Exception
    {
        public string designFile { get; }
        public ParseTreeStatus status { get; }
        public LogMessageList messages { get; }

        public override string Message
        {
            get
            {
                string res = string.Format("{0} : {1}", designFile, status);
                foreach (var msg in messages)
                    res += string.Format("\n{0} {1}", msg.Location, msg.Message);
                return res;
            }
        }

        public ParserException(string designFile, ParseTreeStatus status, LogMessageList messages)
        {
            this.designFile = designFile;
            this.status = status;
            this.messages = messages;
        }
    }
}
