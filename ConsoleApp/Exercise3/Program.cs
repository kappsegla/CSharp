using System;
using ConsoleApp.Shapes;

namespace ConsoleApp.Exercise3
{
    public class Program
    {
        // private static void Main(string[] args)
        // {
        //
        //     DisplayMenu();
        //
        //
        //
        //
        // }

        public Shape CreateShape(ShapeType type){

            switch (type)
            {
                case ShapeType.Ellipse:
                    return new Ellipse();
                case ShapeType.Rectangle:
                    return new Rectangle();
                default:
                    return null;
            }
        }

    }

    public class Ellipse : Shape
    {
        public override double Area { get; }
    }

    public class Rectangle : Shape
    {
        public override double Area { get; }
    }

    public enum ShapeType
    {
        Ellipse,
        Rectangle
    }
    
}