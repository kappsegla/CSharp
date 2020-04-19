using System;

namespace ConsoleApp
{
    public class Counter
    {
        private static int _instances = 0;

        public Counter()
        {
            _instances++;

        }

        public static void Print()
        {
            Console.WriteLine(_instances);
        }



    }
}