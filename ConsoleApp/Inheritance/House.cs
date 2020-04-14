namespace ConsoleApp.Inheritance
{
    public class House
    {
        //Must use composition, because C# doesn't allow inheritance from several classes.
        public BedRoom Sleeping { get; set; }
        public Kitchen Cooking { get; set; }
        public BathRoom Washing { get; set; }
    }
}