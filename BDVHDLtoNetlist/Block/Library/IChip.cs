using BDVHDLtoNetlist.Block.Signal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Block.Library
{
    interface IChip
    {
        // ゲートのシグナル -> チップのピン
        Dictionary<ISignal, ISignal>[] portNameMappings { get; }

        // チップのピン -> 信号名
        Dictionary<ISignal, SignalName> constAssignMappings { get; }

    }
}
