using System;

namespace ConsoleApp.Shapes
{
    public class Circle : Shape
    {
        private double _size;

        public Circle(double size)
        {
            _size = size;
        }

        public override void PrintType()
        {
            Console.WriteLine("This is a Sphere");
        }

        public override double Area
        {
            get { return _size * _size * Math.PI; }
        }
    }
}