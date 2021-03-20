using BDVHDLtoNetlist.Block.Chip;
using BDVHDLtoNetlist.Compiler;
using BDVHDLtoNetlist.Writer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BDVHDLtoNetlist
{
    class Program
    {
        static void Main(string[] args)
        { 
            string programFile = args[0];
            string chipDefinitionDirectory = args[1];
            string outFile = args[2];

            var mainObject = (new Parser.MyParser()).Parse(programFile);
            Console.WriteLine("------ {0} ------", programFile);
            mainObject.Print();


            var chipDefinitions = new List<IChipDefinition>();

            foreach (string chipDesignFile in 
                System.IO.Directory.GetFiles(chipDefinitionDirectory, "*.vhd"))
            {
                IChipDefinition chipDefinition = GateChipDefinition.ImportFromFile(chipDesignFile);
                if (chipDefinition == null)
                    chipDefinition = ComponentChipDefinition.ImportFromFile(chipDesignFile);
                if (chipDefinition == null)
                    continue;

                chipDefinitions.Add(chipDefinition);

                Console.WriteLine();
                Console.WriteLine("------ {0} ------", chipDesignFile);
            }


            var compiler = new Compiler.Compiler();
            compiler.Compile(mainObject, chipDefinitions);

            Console.WriteLine();
            Console.WriteLine("-----------------");

            foreach (var parts in compiler.netComponents)
                if(parts.chip is ComponentChipDefinition)
                    Console.WriteLine("[LIBPARTS]: {0} ({1})", ((ComponentChipDefinition)parts.chip).chipAttribute["component_name"], parts.GetHashCode());
                else if(parts.chip is GateChipDefinition)
                    Console.WriteLine("[LIBPARTS]: {0} ({1})", ((GateChipDefinition)parts.chip).chipAttribute["component_name"], parts.GetHashCode());

            foreach (var pair in compiler.representingNet)
            {
                Console.WriteLine("[NET]: {0} -> {1}", pair.Key, pair.Value.name);
                foreach (var node in pair.Value.adjacentNodes)
                    Console.WriteLine("\t{0}:pin{1}", node.netComponent.GetHashCode(), node.pin);
            }


            (new Writer.Writer()).Write(compiler, outFile);


            // パーツリストを出力
            var componentList = new Dictionary<IChipDefinition, int>();
            foreach (var netComponent in compiler.netComponents)
            {
                if (!componentList.ContainsKey(netComponent.chip))
                    componentList[netComponent.chip] = 0;
                componentList[netComponent.chip]++;
            }

            Console.WriteLine();
            Console.WriteLine("----- partslist -----");
            foreach (var pair in componentList)
                Console.WriteLine("{0} : {1}", pair.Key.chipAttribute["component_name"], pair.Value);
            Console.WriteLine("sum : {0}", componentList.Values.Sum());

            Console.ReadKey();

        }
    }
}
