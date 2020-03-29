using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
        private const int Age = 1;
        private static bool canDo = false;

        private string Name { get; set; }

        // private static void Main(string[] args)
        // {
        //     Console.WriteLine("Hello World!");
        //     var list = new List<int>();
        //     
        //     var p = new Program();
        // }
        //

        static int ParseInt(string s)
        {
            // int i;
            // bool b = Int32.TryParse(s, out i);
            // if (b)
            //     return i;
            // throw new Exception("Couldn't parse string");
            //
            //Or
            return Convert.ToInt32(s);
        }
    }
}