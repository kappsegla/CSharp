using System;
using System.Collections.Generic;

namespace ConsoleApp.Functions
{
    public class Functions
    {
        public delegate void Deli(string message);

        public void PrintMessage(string mess)
        {
            Console.WriteLine(mess);
        }

        public void HigherOrderFunction(Action<string> deli)
        {
            deli("Hi from higher order function");
        }

        public static IEnumerable<int> Where(int[] arr, Func<int,bool> filter)
        {
            foreach (int n in arr)
            {
                if (filter(n))
                    yield return n;
            }
        }

        public static IEnumerable<int> Numbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
        }

        public static IEnumerable<int> UnlimitedNumbers()
        {
            //This method will return an "unlimited" series of numbers.
            int value = 0;
            while (true)
            {
                yield return value++;
            }
        }

        public static IEnumerable<int> GreaterThan(int[] arr, int gt)
        {
            List<int> temp = new List<int>();
            foreach (int n in arr)
            {
                if (n > gt) temp.Add(n);
            }
            return temp;
        }
        
        // public static IEnumerable<int> LessThan(int[] arr, int lt)
        // {
        //     List<int> temp = new List<int>();
        //     foreach (int n in arr)
        //     {
        //         if (n < lt) temp.Add(n);
        //     }
        //     return temp;
        // }

        public void Run()
        {
            int[] arr = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var enumerable = Where(arr, m => m > 5);
            foreach (var i in enumerable)
            {
                Console.WriteLine(i);
            }

            foreach (var i in UnlimitedNumbers())
            {
                Console.WriteLine(i);
            }


            // Deli deliMethodRef;
            // deliMethodRef = PrintMessage;
            //
            // PrintMessage("Direct call to PrintMessage");
            // deliMethodRef("Call with Deli delegate");
            //
            // //HigherOrderFunction(deliMethodRef);
            // HigherOrderFunction(PrintMessage);
            // HigherOrderFunction(m =>
            //     Console.WriteLine("Lambda version " + m));


            // Rectangle rectangle = new Rectangle() {Height = 10, Length = 10};
            // rectangle.Grow(1, 1);
            //
            // ImmutableRectangle immutableRectangle = new ImmutableRectangle(10, 10);
            // immutableRectangle = immutableRectangle.Grow(1, 1);
        }

        // imperative, mutates state to produce a result
        // public static string GetSalutation(int hour)
        // {
        //     string salutation; // placeholder value
        //     if (hour < 12)
        //         salutation = "Good Morning";
        //     else
        //         salutation = "Good Afternoon";
        //
        //     return salutation; // return mutated variable
        // }

        public static string GetSalutation(int hour) =>
            hour < 12 ? "Good Morning" : "Good Afternoon";

        // public static IEnumerable<int> GreaterThan(int[] arr, int gt)
        // {
        //     List<int> temp = new List<int>();
        //     foreach (int n in arr)
        //     {
        //         if (n > gt) temp.Add(n);
        //     }
        //
        //     return temp;
        // }
        //
        // public static IEnumerable<int> GreaterThan(int[] arr, int gt)
        // {
        //     foreach (int n in arr)
        //     {
        //         if (n > gt) yield return n;
        //     }
        // }
        //


        public delegate void Del(string message);

        // Create a method for a delegate.
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }
    }


    // Mutable type
    public class Rectangle
    {
        public int Length { get; set; }
        public int Height { get; set; }

        public void Grow(int length, int height)
        {
            Length += length;
            Height += height;
        }
    }

    //Immutable type
    public class ImmutableRectangle
    {
        int Length { get; }
        int Height { get; }

        public ImmutableRectangle(int length, int height)
        {
            Length = length;
            Height = height;
        }

        public ImmutableRectangle Grow(int length, int height) =>
            new ImmutableRectangle(Length + length, Height + height);
    }
}