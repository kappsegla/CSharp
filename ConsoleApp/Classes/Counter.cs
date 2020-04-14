namespace ConsoleApp.Classes
{
    public class Counter
    {
        private int counter;

        public void Increase()
        {
            counter++;
        }

        public void Decrease()
        {
            counter--;
        }

        public override string ToString()
        {
            return counter.ToString();
        }
    }
}