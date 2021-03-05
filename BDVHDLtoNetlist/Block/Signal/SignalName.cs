using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Block.Signal
{
    class SignalName
    {
        public string baseName { get; }
        public int? stIndex { get; }
        public int? edIndex { get; }

        public bool isTemp { get; private set; } = false;

        public void SetTemp()
        {
            this.isTemp = true;
        }

        public SignalName(string baseName, int? stIndex = null, int? edIndex = null)
        {
            this.baseName = baseName;
            this.stIndex = stIndex;
            this.edIndex = edIndex;
        }

        public static SignalName Parse(string sName)
        {
            var nameMatch = Regex.Match(sName, @"^[^\[]+");

            var sliceMatch = Regex.Match(sName, @"\[(\d+)\.\.(\d+)\]$");
            if (sliceMatch.Success)
                return new SignalName(nameMatch.Value, int.Parse(sliceMatch.Groups[1].Value), int.Parse(sliceMatch.Groups[2].Value));

            var indexMatch = Regex.Match(sName, @"\[(\d+)\]$");
            if (indexMatch.Success)
                return new SignalName(nameMatch.Value, int.Parse(indexMatch.Groups[1].Value));

            return new SignalName(nameMatch.Value);
        }

        public override string ToString()
        {
            if(edIndex == null && stIndex == null)
                return baseName;
            else if(edIndex == null)
                return string.Format("{0}[{1}]", baseName, stIndex);
            else
                return string.Format("{0}[{1}..{2}]", baseName, stIndex, edIndex);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            else
                return this.baseName == ((SignalName)obj).baseName &&
                    this.stIndex == ((SignalName)obj).stIndex &&
                    this.edIndex == ((SignalName)obj).edIndex;
        }

        public override int GetHashCode()
        {
            return this.baseName.GetHashCode() ^ this.stIndex.GetHashCode() ^ this.edIndex.GetHashCode();
        }
    }
}
