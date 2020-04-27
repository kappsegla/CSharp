using System;

public class Point
{
	public double X { get; set; }
	public double Y { get; set; }

	public double DistanceTo(Point other)
	{
		var s1 = this.X - other.X;
		var s2 = this.Y - other.Y;

		var length = Math.Sqrt(s1 * s1 + s2 * s2);
		return length;
	}
}
