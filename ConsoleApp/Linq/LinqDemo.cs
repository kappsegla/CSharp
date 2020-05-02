using System;
using System.Linq;

namespace ConsoleApp.Linq
{
    //LINQ is query language. It can only filter and transform data.
    //That what LINQ is intended for.

    public class LinqDemo
    {
        //Query syntax:
        public void Demo1()
        {
            // The Three Parts of a LINQ Query:
            // 1. Data source.
            int[] numbers = new int[7] {0, 1, 2, 3, 4, 5, 6};

            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            // 3. Query execution.
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }
        }

        
        //Method syntax:
        public void Demo2()
        {
            int[] numbers = new int[7] {0, 1, 2, 3, 4, 5, 6};

            var enumerable = numbers.Where(i => i % 2 == 0);
            
            foreach (var i in enumerable)
            {
                
            }

        }
    }
}