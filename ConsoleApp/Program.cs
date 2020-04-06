using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = 10;

            //Create an object of type Rectangle
            Rectangle rectangle = new Rectangle();

            rectangle.height = 10;
            rectangle.width = 5;
            
            Rectangle rectangle1 = new Rectangle();

            rectangle1.height = 20;
            rectangle1.width = 30;

            Console.WriteLine(rectangle.height);
            Console.WriteLine(rectangle1.height);

            int[] array = new int[10];
            Rectangle[] rectangles = new Rectangle[10];

            array[0] = 20;

            //Arrays of Rectangles is just an array of Rectangle references, initiated to null. Loop and create the Rectangle objects.
            for (int i = 0; i < rectangles.Length; i++)
            {
                rectangles[i] = new Rectangle();
                rectangles[i].height = 20;
            }

            //If you set all references pointing to an object to null the garbage collector can free the memory and remove the object.
            rectangle = null;











            // Console.WriteLine("Hello World!");
            // PrintGreeting();
            // PrintGreetingWithName("Martin");
            // //Alt1
            // int i = GetAge();
            // Console.WriteLine(i);
            // //Alt2
            // Console.WriteLine( GetAge() );
            //
            // double sum = Add(2.0, 3.0);
            // Console.WriteLine(sum);
            // int intsum =  Add(1, 2);
            // var sum2 = Add(1, 2, 3);


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
            return i1 + i2 + i3;}
        

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