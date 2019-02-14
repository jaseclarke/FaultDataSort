using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaultDataSort
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Arguments are [Source File] [Destination File]");
                return;
            }

            string sourceFile = args[0];
            string destFile = args[1];

            if (!File.Exists(sourceFile))
            {
                Console.WriteLine($"Source File: {sourceFile} not found.");
                return;
            }

            if (File.Exists(destFile))
            {
                Console.WriteLine($"Destination File: {destFile} already exists.");
                return;
            }

            FaultFileSorter.Sort(sourceFile,destFile);

        }

    }
}
