using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Block.Signal
{
    class SignalName
    {
        public string baseName { get; }
        public int? index { get; }

        public SignalName(string baseName, int? index = null)
        {
            this.baseName = baseName;
            this.index = index;
        }

        public static SignalName Parse(string value)
        {
            string baseName;
            int? index = null;

            var indexMatch = System.Text.RegularExpressions.Regex.Match(value, @"\[\d+\]$");
            if (indexMatch == null)
                baseName = value;
            else
            {
                baseName = value.Substring(0, value.Length - indexMatch.Value.Length);
                index = int.Parse(indexMatch.Value.Trim("[]".ToCharArray()));
            }

            return new SignalName(baseName, index);
        }

        public override string ToString()
        {
            if(index == null)
                return baseName;
            else
                return string.Format("{0}[{1}]", baseName, index);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            else
                return this.baseName == ((SignalName)obj).baseName &&
                    this.index == ((SignalName)obj).index;
        }

        public override int GetHashCode()
        {
            return this.baseName.GetHashCode() * 32 + this.index.GetHashCode();
        }
    }
}
