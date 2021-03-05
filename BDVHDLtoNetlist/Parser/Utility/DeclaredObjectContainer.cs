using BDVHDLtoNetlist.Block.Component;
using BDVHDLtoNetlist.Block.Gate;
using BDVHDLtoNetlist.Block.Signal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Parser.Utility
{
    class DeclaredObjectContainer
    {
        public ComponentPrototype entityPrototype;
        public Dictionary<string, object> entityAttribute;

        public SignalTable signalTable;
        public Dictionary<string, ComponentPrototype> componentDeclarations;

        public List<KeyValuePair<ISignal, ISignal>> assignments;
        public List<LogicGate> logicGates;
        public List<Component> components;

        public TempSignalNameGenerator signalNameGenerator;

        public DeclaredObjectContainer()
        {
            this.entityAttribute = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            this.signalTable = new SignalTable();
            this.componentDeclarations = new Dictionary<string, ComponentPrototype>(StringComparer.OrdinalIgnoreCase);
            this.assignments = new List<KeyValuePair<ISignal, ISignal>>();
            this.logicGates = new List<LogicGate>();
            this.components = new List<Component>();
            this.signalNameGenerator = new TempSignalNameGenerator();
        }

        public void Print()
        {
            foreach (var pair in this.entityAttribute)
                Console.WriteLine("[ATTRIBUTE] {0} -> {1}", pair.Key, pair.Value.ToString());

            foreach (string signalName in this.signalTable.Keys)
                Console.WriteLine("[SIGNAL] ({0}) -> ({1})", signalName, this.signalTable[signalName]);

            foreach (var tuple in this.assignments)
                Console.WriteLine("[ASSIGN] ({0}) <- ({1})", tuple.Key, tuple.Value);

            foreach (var gate in this.logicGates)
            {
                Console.Write("[GATE] ({0}) <- ({1}) ", gate.outputSignal, gate.gateType);
                foreach (var inputSignal in gate.inputSignals)
                    Console.Write("({0}), ", inputSignal);
                Console.WriteLine();
            }

            foreach (var componentPrototype in this.componentDeclarations)
            {
                Console.WriteLine("[COMPONENT_DECLR] {0}:", componentPrototype.Key);
                foreach (var signal in componentPrototype.Value.signals)
                    Console.WriteLine("\t{0}", signal);
            }

            foreach (var component in this.components)
            {
                Console.WriteLine("[COMPONENT] {0}: {1}", component.name, component.prototype.name);
                foreach (var signal in component.portMap.Keys)
                    Console.WriteLine("\t{0} -> {1}", signal, component.portMap[signal]);
            }
        }
    }
}
