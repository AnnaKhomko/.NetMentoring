using FirstCharsApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstCharsApp
{
    public class ProcessLine
    {
        public List<string> GetEnteredLines()
        {
            var enteredLines = new List<string>();
            Console.WriteLine("Enter lines. Press ESC to stop entering.");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                try
                {
                    string currentLine = Console.ReadLine();
                    ValidateLine(currentLine);
                    enteredLines.Add(currentLine);
                }
                catch (EmptyLineException ex)
                {
                    Console.WriteLine($"Error message: {ex.Message}");
                }
            }
            return enteredLines;
        }

        public void PrintFirstChar(List<string> lines)
        {
            foreach(var line in lines)
            {
                Console.WriteLine(line[0].ToString());
            }
        }

        private void ValidateLine(string line)
        {
            Match match = Regex.Match(line, @"^[ \t\r\n\s]*$");

            if (string.IsNullOrEmpty(line) || match.Success)
            {
                throw new EmptyLineException();
            }
        }
    }
}
