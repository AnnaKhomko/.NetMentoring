using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParserForInt
{
    public class Parser
    {
        public bool FintFloats(string str)
        {
            String separ = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            var res = new Regex(@"\s*[0-9]*\" + separ + "[0-9]+$");
            return res.IsMatch(str);
        }

        public bool FindIntegers(string str)
        {
            var res = new Regex(@"^[+|-]?\d{1,10}$");
            return res.IsMatch(str);
        }

        public long ConvertToLong(string str)
        {
            long result = 0;
            if (str[0] == '-' || str[0] == '+')
            {
                for (int i = 1; i < str.Length; i++)
                    result = checked(result * 10 + ParseCharToInt(str[i]));
                if (str[0] == '-')
                    result = -result;
               
            }
            
            else
            {
                for (int i = 0; i < str.Length; i++)
                result = checked(result * 10 + ParseCharToInt(str[i]));
            }
            return result;
        }

        public bool FindStringLength(string str)
        {
            bool flag;
            if ((str[0] == '-') && (str.Length <= 11))
                flag = true;
            else if ((str[0] != '-') && (str.Length <= 10))
                flag = true;
            else flag = false;

            return flag; 

        }

        private static int ParseCharToInt(char c)
        {
            return c - '0';
        }
    }
}
