using System;
using System.Collections.Generic;

namespace ConsoleApp.Functions
{
    public class Functions
    {
        public void Run()
        {
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