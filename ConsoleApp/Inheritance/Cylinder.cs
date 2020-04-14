namespace ConsoleApp.Inheritance
{
    public class Cylinder : Circle
    {
        public float Height { get; set; }

        public override string ToString()
        {
            return "This is a Cylinder, and we are in its ToString method";
        }
    }
}