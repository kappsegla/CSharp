namespace ConsoleApp.TestExample
{
    public class Calculator
    {
        public static int Add(int x, int y) => x + y;
        public static int Subtract(int x, int y) => x - y;

        public static bool IsEven(int x)
        {
            return x % 2 == 0;
        }

        private int i = 10;

        public void ChangeSomething()
        {
            i++;
        }

        public int GetSomething()
        {
            return i;
        }
    }
}