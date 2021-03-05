using BDVHDLtoNetlist.Block.Chip;
using BDVHDLtoNetlist.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BDVHDLtoNetlist
{
    class Program
    {
        static void Main(string[] args)
        {
            // string programFile = args[0];
            string programFile = "test00.vhd";
            string chipDefinitionDirectory = @"..\..\library";

            string program = System.IO.File.ReadAllText(programFile);
            var mainObject = (new Parser.MyParser()).Parse(program);
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
                chipDefinition.Print();
            }


            var compiler = new Compiler.Compiler();
            compiler.Compile(mainObject, chipDefinitions);

            Console.WriteLine();
            Console.WriteLine("-----------------");

            foreach (var parts in compiler.libParts)
                if(parts.chip is ComponentChipDefinition)
                    Console.WriteLine("[LIBPARTS]: {0} ({1})", ((ComponentChipDefinition)parts.chip).chipAttribute["component_name"], parts.GetHashCode());
                else if(parts.chip is GateChipDefinition)
                    Console.WriteLine("[LIBPARTS]: {0} ({1})", ((GateChipDefinition)parts.chip).chipAttribute["component_name"], parts.GetHashCode());

            foreach (var pair in compiler.representingNet)
            {
                Console.WriteLine("[NET]: {0} -> {1}", pair.Key, pair.Value.name);
                foreach (var node in pair.Value.adjacentNodes)
                    Console.WriteLine("\t{0}:pin{1}", node.libParts.GetHashCode(), node.pin);
            }

            Console.ReadKey();
        }
    }
}
