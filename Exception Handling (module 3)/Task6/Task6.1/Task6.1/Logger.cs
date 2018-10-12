using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6._1
{
    public class Logger
    {
      
     
         public string FilePath { get; } 
 
 
         public Logger(string filePath)
         { 
             this.FilePath = filePath; 
         } 
 
 
         public void WriteToLogger(string message)
         { 
             File.AppendAllText(FilePath, $"\r\n{message}\r\n"); 
         } 
      

    }
}
