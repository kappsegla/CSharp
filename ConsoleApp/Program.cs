using System;
using System.Collections;
using System.Collections.Generic;
using ConsoleApp.Animals;
using ConsoleApp.Classes;
using ConsoleApp.Exercise2;
using ConsoleApp.Files;
using ConsoleApp.Generics;
using ConsoleApp.Inheritance;
using ConsoleApp.Linq;
using ConsoleApp.Shapes;
using Circle = ConsoleApp.Inheritance.Circle;
using Cylinder = ConsoleApp.Inheritance.Cylinder;
using Point = ConsoleApp.Generics.Point;

namespace ConsoleApp
{
   class Program
    {
        static void Main(string[] args)
        {
            //Uncomment the code you want to try

            //CreateObjects();

            //FiftyGame.Run();

            //Animals();

            //Generics();

            //Point();

            //StackExample();
            
            //new LinqExercise.Linq().Run();
            
            //new FileHandling().Run();
            Exercise3.Program.Run();
        }

        private static void StackExample()
        {
            Generics.Stack<string> stack = new Generics.Stack<string>(); 
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");
            
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
        }

        private static void Point()
        {
            Point point1 = new Point() {X = 4.0, Y = 3.0};
            
            Point point2 = new Point(0.0,0.0);

            var distance = point1.DistanceTo(point2);
            
            Console.WriteLine(distance);
            
            //Create a new object, copy data from point1
            Point point3 = new Point(point1);

            //Create a new object that is a copy of point1s data
            Point point4 = (Point)point1.Clone();

            //Copy data from point1 into our new point5
            Point point5 = new Point();
            point1.CopyTo(point5);
        }

        private static void Generics()
        {
            Storage<int> storage = new Storage<int>();
            storage.Save(7);
            int tal = storage.Get();

            var storage1 = new Storage<double>();
            storage1.Save(1.0);

            var storage2 = new Storage<string>();
            var storage3 = new Storage<Mammal>();
        }

        static Mammal CreateMammal(Mammals type)
        {
            switch (type)
            {
                case Mammals.cat:
                    return new Cat();

                case Mammals.dog:
                    return new Dog();
            }

            return null;
        }

        enum Mammals
        {
            cat,
            dog,
            fox
        }


        static void Animals()
        {
            List<Cat> cats = new List<Cat>()
            {
                new Cat() {Weight = 10},
                new Cat() {Weight = 2},
                new Cat() {Weight = 1},
                new Cat() {Weight = 3}
            };

            foreach (var c in cats)
            {
                Console.WriteLine(c.Weight);
            }

            cats.Sort();
            foreach (var c in cats)
            {
                Console.WriteLine(c.Weight);
            }


            Dog dog = new Dog();
            Mammal mammal = CreateMammal(Mammals.dog);

            Cat cat = new Cat();
            Mammal mammal2 = new Cat();
            IPet pet = new Cat();
            pet.IsHungry();

            // IPet pet2 = new Fox();

            Mammal[] mammals = new Mammal[2];

            mammals[0] = dog;
            mammals[1] = cat;

            //Can't instanciate Mammal, abstract class.
            //Mammal mammal3 = new Mammal();

            dog.Talk();
            mammal.Talk();
            cat.Talk();
            mammal2.Talk();

            mammal2 = dog;
            mammal2.Talk();

            Mammal foxMammal = new Fox();
            foxMammal.Talk();


            /*  Point point = new Point();
              Point point2 = new Point { X = 1, Y = 2 };
              Point point3 = new Point(1, 2);
  
              
              point.X = 10;
              Console.WriteLine(point.Y);
  
              */
        }

        static void CreateObjects()
        {
            Cylinder cylinder = new Cylinder();
            Circle circle = new Circle();

            Circle circle2 = new Cylinder();
            //Cylinder cylinder2 = new Circle();

            //Implicit typecasting, automatic
            Object o2 = new Circle();

            //Explicit typecasting (type)
            Circle circle1 = (Circle) o2;

            //Not allowed. Will cast InvalidCastException
            //Cylinder cylinder2 = (Cylinder)o2;

            Object o1 = new Object();

            Console.WriteLine(o1.GetType());
            Console.WriteLine(cylinder.GetType());
            Console.WriteLine(cylinder.ToString());


            Shape shape = new Shapes.Circle(1.0);
            Shape shape1 = new Square(1.0);

            Shape[] shapes = new Shape[2];

            shapes[0] = new Square(1.0);
            shapes[1] = new Shapes.Circle(1.0);

            for (int i = 0; i < shapes.Length; i++)
            {
                shapes[i].PrintType();
            }
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