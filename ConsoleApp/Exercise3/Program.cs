using System;
using System.Text;

namespace ConsoleApp.Exercise3
{
    public enum ShapeType
    {
        Ellipse,
        Rectangle
    }

    public class Program
    {
        static Shape CreateShape(ShapeType type, double l, double w)
        {
            switch (type)
            {
                case ShapeType.Ellipse:
                    return new Ellipse(l, w);
                //Console.WriteLine("{0:F2}", Shape.area());
                case ShapeType.Rectangle:
                    return new Rectangle(l, w);
                default:
                    return null;
            }
        }

        static void ViewShapeInfo(Shape shape)
        {
            //ToString will be called automatically on object references from WriteLine
            //Console.WriteLine(shape.ToString());
            Console.WriteLine(shape);
        }

        // Main Method
        //   private static void Main(string[] args)
        public static void Run()
        {
            //Display menu
            while (true)
            {
                Console.WriteLine("0.Exit\n1. Rectangle\n2. Ellipse");
                Console.Write("Select shape: ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                    return;
                
                Console.Write("Please enter the length: ");
                var length = double.Parse(Console.ReadLine());
                Console.Write("Please enter the width: ");
                var width = double.Parse(Console.ReadLine());

                Shape shape;

                switch (choice)
                {
                    case 1:
                        shape = CreateShape(ShapeType.Rectangle, length, width);
                        ViewShapeInfo(shape);
                        break;
                    case 2:
                        shape = CreateShape(ShapeType.Ellipse, length, width);
                        ViewShapeInfo(shape);
                        break;
                    default:
                        Console.WriteLine("Not implemented.");
                        break;
                }
            }
        }
    }

    public abstract class Shape : IComparable<Shape>
    {
        private double _length;
        private double _width;

        protected Shape(double length, double width)
        {
            _length = length;
            _width = width;
        }

        protected double Length
        {
            get => _length;
            set
            {
                if (value >= 0) _length = value;
            }
        }

        protected double Width
        {
            get => _width;
            set
            {
                if (value >= 0) _width = value;
            }
        }

        public abstract double Area { get; }
        public abstract double Perimeter { get; }

        public int CompareTo(Shape other)
        {
            return Area.CompareTo(other.Area);
        }

        public override string ToString()
        {
            return "Längd : " + _length + "\nBredd : " + _width + "\nPerimeter : " + Perimeter + "\nArea:" + Area;
        }
    }

    public class Ellipse : Shape
    {
        public Ellipse(double length, double width) : base(length, width)
        {
        }

        public override double Area
        {
            get { return Math.PI * (Width / 2.0) * (Length / 2.0); }
        }

        //2πSqrt((r1² + r2²) / 2)
        public override double Perimeter
        {
            get
            {
                return 2 * Math.PI *
                       Math.Sqrt(((Width / 2.0) * (Width / 2.0) + (Length / 2.0) * (Length / 2.0)) / 2.0);
            }
        }
    }

    public class Rectangle : Shape
    {
        public override double Area
        {
            get { return Length * Width; }
        }

        public override double Perimeter
        {
            get { return 2 * (Length + Width); }
        }

        public Rectangle(double length, double width) : base(length, width)
        {
        }
    }
}