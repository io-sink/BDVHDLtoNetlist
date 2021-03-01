using System;

namespace BDVHDLtoNetlist
{
    class Program
    {
        static void Main(string[] args)
        {
            string programFile = "test01.vhd";
            string program = System.IO.File.ReadAllText(programFile);

            (new Parser.MyParser()).Parse(program);
            Console.ReadKey();
        }
    }
}
