using System;

namespace NetStandartLibrary
{
    public class ClassWriter
    {
        public static string WriteHello(string name)
        {
            string curTimeLong = DateTime.Now.ToLongTimeString();
            return $"{curTimeLong}: Hello, {name}!";
        }
    }
}
