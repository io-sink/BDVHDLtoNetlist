using BDVHDLtoNetlist.Block.Library;
using System;

namespace BDVHDLtoNetlist
{
    class Program
    {
        static void Main(string[] args)
        {
            string programFile = "test01.vhd";
            string program = System.IO.File.ReadAllText(programFile);
            var mainObject = (new Parser.MyParser()).Parse(program);


            string nand2File = "7400ic.vhd";
            var nand2Chip = GateChip.ImportFromFile(nand2File);
            nand2Chip.Print();


            string quadMux2File = "4053ic_mux.vhd";
            var quadMux2Chip = ComponentChip.ImportFromFile(quadMux2File);
            quadMux2Chip.Print();


            Console.ReadKey();
        }
    }
}
