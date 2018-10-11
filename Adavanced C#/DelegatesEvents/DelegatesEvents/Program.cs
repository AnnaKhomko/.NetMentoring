using DelegatesEvents.Wrappers;
using DelegatesEvents.Wrappers.Interfaces;
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
            DirectoryInfo directoryInfo = new DirectoryInfo(fileDirectory);

            FileSystemVisitor filesv = new FileSystemVisitor((item) =>
            {
                return !item.Name.Contains(".jpg");
            });

            filesv.OnStart += (e, s) =>
             {
                 Console.WriteLine("Search starts!");
             };

            filesv.OnFinish += (e, s) =>
            {
                Console.WriteLine("Search ends!");
            };

            filesv.OnFileFinded += (e, s) =>
            {
                Console.WriteLine($"File {s.Item.Name} finded");
            };

            filesv.OnDirectoryFinded += (e, s) =>
            {
                Console.WriteLine($"Directory {s.Item.Name} finded");
            };

            filesv.OnFileFiltered += (e, s) =>
            {
                if (s.Item.Name.Contains("cat"))
                {
                    s.Action = ActionType.Skip;
                }
                Console.WriteLine($"File {s.Item.Name} filtered");
            };

            filesv.OnDirectoryFiltered += (e, s) =>
            {
                if (s.Item.Name.Length <= 8)
                {
                    s.Action = ActionType.Stop;
                }
                Console.WriteLine($"Directory {s.Item.Name} filtered");
            };

            var wrapper = new DirectoryInfoWrapper(directoryInfo);

            foreach (IFileSystemInfoWrapper fileSysInfo in filesv.StartProcess(wrapper))
            {
                Console.WriteLine(fileSysInfo);
            }

            Console.ReadKey();
        }
    }
}
