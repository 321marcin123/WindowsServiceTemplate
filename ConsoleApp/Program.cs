using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var logic = new ProcessingSetupAndRun();
            logic.Setup();
            logic.Run();
            Console.ReadKey();

        }
    }
}
