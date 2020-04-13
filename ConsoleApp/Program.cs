using System;
using System.Collections.Generic;
using ConsoleApp.animals;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mammal m = new Dog();
            m.Talk();

            //Counter counter = new Counter();
        }

        static void InitializeRectangle()
        {
            //Create an object of type Rectangle
            Rectangle rectangle = new Rectangle();

            //Set values with Properties
            rectangle.Height = 10;
            rectangle.Width = 5;
            rectangle.Color = "Red";

            //Call a method on the rectangle
            int area = rectangle.Area();

            //Use object initializers
            Rectangle rectangle2 = new Rectangle {Height = 10, Width = 5, Color = "Red"};

            //Use Constructor for initialization
            Rectangle rectangle3 = new Rectangle(10, 5, "Red");


            //Create an array for storing rectangles
            Rectangle[] rectangles = new Rectangle[10];

            //Arrays of Rectangles is just an array of Rectangle references, initiated to null. Loop and create the Rectangle objects.
            for (int i = 0; i < rectangles.Length; i++)
            {
                rectangles[i] = new Rectangle();
                //Set some properties
                //rectangles[i].height = 20;
            }

            //If you set all references pointing to an object to null the garbage collector can free the memory and remove the object.
            rectangle = null;
        }

        //Överlagring  - Overloaded - Methods has the same name, differs in parameters.
        //Parameter type and/or Number of parameters
        //Returntype is not part of method signature
        static double Add(double d1, double d2)
        {
            return d1 + d2;
        }

        static int Add(int i1, int i2)
        {
            return i1 + i2;
        }

        //Not allowed with just different return types
        // static string Add(int i1, int i2)
        // {
        //     return "" + i1 + i2;
        // }

        static int Add(int i1, int i2, int i3)
        {
            return i1 + i2 + i3;
        }


        static void PrintGreeting()
        {
            Console.WriteLine("Hello there!");
        }

        static void PrintGreetingWithName(string name)
        {
            Console.WriteLine("Hello " + name);
        }

        static int GetAge()
        {
            return 40;
        }
    }
}