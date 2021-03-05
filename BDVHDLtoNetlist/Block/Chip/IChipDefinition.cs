using BDVHDLtoNetlist.Block.Signal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Block.Chip
{
    interface IChipDefinition
    {
        // ゲートのシグナル -> チップのピン
        Dictionary<ISignal, ISignal>[] portNameMappings { get; }
        // チップのピン -> 信号名
        Dictionary<ISignal, SignalName> constAssignMappings { get; }

        Dictionary<string, object> chipAttribute { get; }

        void Print();
    }
}
