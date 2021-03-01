using BDVHDLtoNetlist.Block.Signal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Block.Component
{
    class Component
    {
        public string name { get; }
        public ComponentPrototype prototype { get; }

        public Dictionary<ISignal, ISignal> portMap { get; }

        public Component(string name, ComponentPrototype prototype, Dictionary<ISignal, ISignal> portMap)
        {
            this.name = name;
            this.prototype = prototype;

            // ポートの対応を検証
            var prototypePortSet = new HashSet<ISignal>(prototype.signals.Values);

            foreach (ISignal portSignal in portMap.Keys)
            {
                if (!prototypePortSet.Contains(portSignal) ||
                    !portMap[portSignal].Assignable(portSignal))
                    throw new Exception("invalid port");
            }

            this.portMap = portMap;
        }
    }
}
