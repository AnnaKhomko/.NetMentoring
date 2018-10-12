using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6._1
{
    public class Controller
    {

        List<char> firstChars;
        List<int> indexesOfEmptyStrings;


        public Controller()
        {

            this.firstChars = new List<char>();
            this.indexesOfEmptyStrings = new List<int>();
        }

        public List<char> ReadFirstChars(string FilePath)
        {
            List<string> allContent = File.ReadLines(FilePath).ToList();
            for (int i = 0; i < allContent.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(allContent[i]))
                {
                    indexesOfEmptyStrings.Add(i);
                }
                else
                {
                    firstChars.Add(allContent[i].ElementAt(0));
                }
            }
            return firstChars;
        }

        public void CheckFileContent()
        {
            if (indexesOfEmptyStrings.Count == 0 && firstChars.Count == 0)
                throw new FileIsEmptyException();

            if (indexesOfEmptyStrings.Count != 0)
            {
                throw new EmptyLinesException();

            }

        }

        public void PrintIndexesOfEmptyStrings()
        {
            Console.WriteLine("Indexes of empty lines are:");
            foreach (var i in indexesOfEmptyStrings)
                Console.Write(i + " \r\n");
        }
    }

}

