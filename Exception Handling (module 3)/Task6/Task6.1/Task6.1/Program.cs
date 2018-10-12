using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            logic.CatchExceptions();
            logic.ShowFirstChars();
            Console.WriteLine($"Detail information about exceptions you can find in {ResourceData.LogFilePath} file");
            Console.ReadLine();
        }
    }
}
