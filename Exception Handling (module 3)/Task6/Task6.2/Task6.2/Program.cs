using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserForInt;

namespace Task6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            Logic logic = new Logic();
           
            var res = logic.DetermeType("3.5");
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
