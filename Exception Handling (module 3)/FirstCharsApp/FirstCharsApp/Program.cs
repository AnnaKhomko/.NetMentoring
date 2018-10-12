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
            Console.WriteLine("Enter lines. Press ESC to stop entering.");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                enteredLines.Add(Console.ReadLine());
            }
        }
    }
}
