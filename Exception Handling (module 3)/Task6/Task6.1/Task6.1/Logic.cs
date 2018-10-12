using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6._1
{
    public class Logic
    {
        Logger logger = new Logger(ResourceData.LogFilePath);
        ConsoleReadWrite consoleReaderWriter;

         Controller controller; 
         List<char> firstChars; 
         string filePath; 
 
 
         public Logic()
         { 
            logger = new Logger(ResourceData.LogFilePath);
            consoleReaderWriter = new ConsoleReadWrite();
            controller = new Controller();
         } 
 
 
         public void CatchExceptions()
         {
            bool isNotValidFileName = true;

            do 
             { 
                 try 
                 { 
                     filePath = consoleReaderWriter.ReadFilePath(); 
                     isNotValidFileName = false; 
                 } 
                 catch (FileNotFoundException ex) 
                 { 
                     isNotValidFileName = true; 
                     logger.WriteToLogger($"{ex.Message}\nDetails:\n{ex.StackTrace}"); 
                     Console.WriteLine(ex.Message); 
                 } 
             } while (isNotValidFileName);


            try
            {
                firstChars = controller.ReadFirstChars(filePath);
                controller.CheckFileContent();
            }
            catch (FileIsEmptyException ex)
            {
                logger.WriteToLogger($"{ex.Message}\nDetails:\n{ex.StackTrace}");
                Console.WriteLine(ex.Message);
            }
            catch (EmptyLinesException ex)
            {
                logger.WriteToLogger($"{ex.Message}\nDetails:\n{ex.StackTrace}");
                Console.WriteLine(ex.Message);
                controller.PrintIndexesOfEmptyStrings();
            }
        } 
         
         public void ShowFirstChars()
         { 
             consoleReaderWriter.PrintFirstChars(firstChars); 
         } 

    }
}
