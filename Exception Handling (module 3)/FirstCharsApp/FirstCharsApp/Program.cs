using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCharsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var enteredLines = new List<string>();
            var lineProcess = new ProcessLine();

            enteredLines = lineProcess.GetEnteredLines();
            lineProcess.PrintFirstChar(enteredLines);
            Console.ReadKey();
        }
    }
}
