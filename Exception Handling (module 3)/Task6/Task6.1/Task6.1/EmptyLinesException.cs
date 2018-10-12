using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6._1
{
    public class EmptyLinesException : Exception
    {
        public override string Message
        {
            get
            {
                return "There are empty strings in this file";
            }
        }
    }
}
