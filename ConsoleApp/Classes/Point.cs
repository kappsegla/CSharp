namespace ConsoleApp.Classes
{
    public class Point
    {
        //Default Constructor
        public Point()
        {

        }

        //Constructor with two parameters
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }


        public int X { get; set; }
        public int Y { get; set; }

        public void DoubleUp()
        {
            X *= 2;
            Y *= 2;
        }

    }
}