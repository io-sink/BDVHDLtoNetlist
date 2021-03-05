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
            string programFile = "test00.vhd";
            string program = System.IO.File.ReadAllText(programFile);
            var mainObject = (new Parser.MyParser()).Parse(program);
            Console.WriteLine("------ {0} ------", programFile);
            mainObject.Print();



            var chipDefinitions = new List<IChipDefinition>();

            string nand2File = "7400ic.vhd";
            var nand2Chip = GateChipDefinition.ImportFromFile(nand2File);
            chipDefinitions.Add(nand2Chip);
            Console.WriteLine("------ {0} ------", nand2File);
            nand2Chip.Print();


            string quadMux2File = "4053ic_mux.vhd";
            var quadMux2Chip = ComponentChipDefinition.ImportFromFile(quadMux2File);
            chipDefinitions.Add(quadMux2Chip);
            Console.WriteLine("------ {0} ------", quadMux2File);
            quadMux2Chip.Print();


            var compiler = new Compiler.Compiler();
            compiler.Compile(mainObject, chipDefinitions);

            Console.WriteLine();
            Console.WriteLine("-----------------");

            foreach (var parts in compiler.libParts)
                if(parts.chip is ComponentChipDefinition)
                    Console.WriteLine("[LIBPARTS]: {0} ({1})", ((ComponentChipDefinition)parts.chip).componentPrototype.name, parts.GetHashCode());
                else if(parts.chip is GateChipDefinition)
                    Console.WriteLine("[LIBPARTS]: {0} ({1})", ((GateChipDefinition)parts.chip).gateType, parts.GetHashCode());

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
