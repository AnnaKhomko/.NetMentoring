using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomParserLibrary
{
    public class CustomParser
    {
        public void ParseToInt(string inputString, out int intResult)
        {
            int temporaryValue = 0;
            if (string.IsNullOrEmpty(inputString))
            {
                throw new ArgumentNullException(inputString);
            }

            if (((inputString[0] == '-' || inputString[0] == '+') && inputString.Length > 11) || 
                !(inputString[0] == '-' || inputString[0] == '+') && (inputString.Length > 10))
            {
                throw new FormatException($"Input string '{inputString}' is too long to be an int number.");
            }

            if (IsInt(inputString))
            {
                if (inputString[0] == '-' || inputString[0] == '+')
                {
                    Parse(inputString.Substring(1), ref temporaryValue);

                    if (inputString[0] == '-')
                        temporaryValue *= -1;
                }
                else
                {
                    Parse(inputString, ref temporaryValue);
                }
                if (temporaryValue < int.MinValue || temporaryValue > int.MaxValue)
                {
                    throw new FormatException($"Input string '{inputString}' has wrong format. Expected: int. Actual: long.");
                }
                intResult = (int)temporaryValue;
            }
            else if (IsFloat(inputString))
            {
                throw new FormatException($"Input string '{inputString}' has wrong format. Expected: int. Actual: float.");
            }
            else
                throw new FormatException($"Input string '{inputString}' has wrong format. Expected: int. Actual: string.");

        }

        private void Parse(string strToParse, ref long temporaryValue)
        {
            foreach (char c in strToParse)
            {
                temporaryValue *= 10;
                temporaryValue += c - '0';
            }
        }

        private bool IsInt(string stringToValidate)
        {
            var res = new Regex(@"^[+|-]?\d{1,10}$");
            return res.IsMatch(stringToValidate);
        }

        private bool IsFloat(string stringToValidate)
        {
            string separ = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            var res = new Regex(@"\s*[0-9]*\" + separ + "[0-9]+$");
            return res.IsMatch(stringToValidate);
        }

        private void Parse(string strToParse, ref int temporaryValue)
        {
            foreach (char c in strToParse)
            {
                temporaryValue *= 10;
                temporaryValue += c - '0';
            }
        }
    }
}
