using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserForInt
{
    public class Logic
    {
        public int DetermeType(string str)
        {
            int result;
            Parser parser = new Parser();
            if (str == null)
                throw new ArgumentException();
            if (str.Length == 0)
                throw new ArgumentException();
            if (!parser.FindStringLength(str))
                throw new OverflowException();

            else if (parser.FindIntegers(str))
            {
                long res = parser.ConvertToLong(str);
                if (res > int.MaxValue || res < int.MinValue)
                {
                    throw new OverflowException();
                }
                else
                    result = (int)res;
            }

            else if (parser.FintFloats(str))
            {
                throw new TypeIsFloatException();
            }
            
            else
            {
                throw new TypeIsStringException() ;
            }
            return result;
        }
    }
}
