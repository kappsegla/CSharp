using System;

namespace ConsoleApp.Generics
{
	public class Point
	{
		public double X { get; set; }
		public double Y { get; set; }

		//Two parameters constructor
		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}

		//Default constructor
		public Point()
		{
		
		}
	
		//Copy constructor
		public Point(Point other)
		{
			X = other.X;
			Y = other.Y;
		}

		public Point Clone()
        {
			return new Point(this);
        }
			
	
		public double DistanceTo(Point other)
		{
			var s1 = this.X - other.X;
			var s2 = this.Y - other.Y;

			var length = Math.Sqrt(s1 * s1 + s2 * s2);
			return length;
		}
	}
}
