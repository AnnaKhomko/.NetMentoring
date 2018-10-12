using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6._1
{
    public class ConsoleReadWrite
    {
        public string ReadFilePath()
        {
            string filePath = null;
            Console.WriteLine("Enter file path, please");
            filePath = Console.ReadLine();
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }
            return filePath;

        }


        public void PrintFirstChars(List<char> firstChars)
         { 
             if (firstChars.Count == 0) 
                 return; 
             Console.WriteLine("First chars in every line are:"); 
             foreach (var c in firstChars) 
             { 
                 Console.WriteLine(c); 
             } 
         } 


    }
}
