﻿using System;

namespace ConsoleApp.Shapes
{
    public class Square : Shape
    {
        private double _size;

        public Square(double size)
        {
            _size = size;
        }


        public override void PrintType()
        {
            Console.WriteLine("This is a Square");
        }

        public override double Area
        {
            get { return _size * _size; }
        }
    }
}