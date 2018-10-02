using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string fileDirectory = @"D:\English";
            FileSystemVisitor filesv = new FileSystemVisitor((item) =>
           {
               return !item.Extension.Contains(".jpg");
           });
            filesv.startEvent += (e, s) =>
             {
                 Console.WriteLine("Search starts!");
             };

            filesv.finishEvent += (e, s) =>
            {
                Console.WriteLine("Search ends!");
            };

            filesv.fileFindedEvent += (e, s) =>
            {
                Console.WriteLine($"File {s.Item.Name} finded" );
            };

            filesv.directoryFindedEvent += (e, s) =>
            {
                Console.WriteLine($"Directory {s.Item.Name} finded");
            };

            filesv.fileFilteredEvent += (e, s) =>
            {
                if (s.Item.Name.Contains("Writing_Sample"))
                {
                    s.Action = ActionType.Skip;
                }
                Console.WriteLine($"File {s.Item.Name} filtered");
            };


            filesv.directoryFilteredEvent += (e, s) =>
            {
                if (s.Item.Name.Length <= 8)
                {
                    s.Action = ActionType.Stop;
                }
                Console.WriteLine($"Directory {s.Item.Name} filtered");
            };
            filesv.StartProcess(fileDirectory);

            Console.ReadKey();
        }
    }
}
