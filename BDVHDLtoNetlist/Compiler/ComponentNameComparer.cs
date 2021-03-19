using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Compiler
{
    class ComponentNameComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string pattern = @"\d+";
            var regex = new Regex(pattern);

            var xSplit = new List<string>();
            var ySplit = new List<string>();

            int pos = 0;
            foreach (Match match in regex.Matches(x))
            {
                if (match.Index != pos)
                    xSplit.Add(x.Substring(pos, match.Index - pos));
                xSplit.Add(match.Value);
                pos = match.Index + 1;
            }
            xSplit.Add(x.Substring(pos));

            pos = 0;
            foreach (Match match in regex.Matches(y))
            {
                if (match.Index != pos)
                    ySplit.Add(y.Substring(pos, match.Index - pos));
                ySplit.Add(match.Value);
                pos = match.Index + 1;
            }
            ySplit.Add(y.Substring(pos));


            for (int i = 0; i < Math.Min(xSplit.Count, ySplit.Count); ++i)
            {
                int xNum, yNum;

                if(int.TryParse(xSplit[i], out xNum) && int.TryParse(ySplit[i], out yNum))
                {
                    if (xNum != yNum)
                        return xNum.CompareTo(yNum);
                    else if (xSplit[i] != ySplit[i])
                        return xSplit[i].CompareTo(ySplit[i]);
                }
                else if(xSplit[i] != ySplit[i])
                    return xSplit[i].CompareTo(ySplit[i]);
            }


            if (xSplit.Count > ySplit.Count)
                return 1;
            else if (xSplit.Count < ySplit.Count)
                return -1;
            else
                return 0;
        }
    }
}
