using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6._1
{
    public class FileIsEmptyException : Exception
    {
        public override string Message
        {
            get
            {
                return "This file is empty";
            }
        }
    }
}
