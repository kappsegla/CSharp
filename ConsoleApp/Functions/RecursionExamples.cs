using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace ConsoleApp.Functions
{
    public class RecursionExamples
    {
        public void Run()
        {
            MethodA();

            // var sumLoop = SumIntsLoop(3);
            // sumLoop.Dump();
            //
            // var sumRecursively = SumIntsRecursive(300000);
            // sumRecursively.Dump();
            //
            // var sumTailRecursive = SumIntsTailRecursive(3, 0);
            // sumTailRecursive.Dump();
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static void MethodA()
        {
            MethodB();
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static void MethodB()
        {
            MethodC();
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static void MethodC()
        {
            BadMethod();
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static void BadMethod()
        {
            throw new ApplicationException("generic bad thing");
        }

        //Sum ints from 1 to n using loop
        public int SumIntsLoop(int n)
        {
            var result = 0;
            for (int i = 1; i <= n; i++)
                result = result + i;
            return result;
        }

        //Sum ints from 1 to n using recursive call
        public int SumIntsRecursive(int n)
        {
            if (n == 0)
                return 0;
            return n + SumIntsRecursive(n - 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static long SumIntsTailRecursive(long n, long sum)
        {
            if (n-- == 0)
                return sum;
            return SumIntsTailRecursive(n, n + sum);
        }
    }
}