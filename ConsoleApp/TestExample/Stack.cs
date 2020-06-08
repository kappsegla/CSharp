using System.Collections.Generic;

namespace ConsoleApp.TestExample
{
    public class Stack<T>
    {
        private List<T> elementsList = new List<T>();
        public int Count()
        {
            return elementsList.Count;
        }

        public T Pop()
        {
            if( Count() == 0)
                throw new System.InvalidOperationException();
            T temp = Peek();
            elementsList.RemoveAt(elementsList.Count-1);
            return temp;
        }

        public T Peek()
        {
            if( Count() == 0 )
                throw new System.InvalidOperationException();
            return elementsList[^1];
        }

        public bool Contains(T value)
        {
            return elementsList.Contains(value);
        }

        public void Push(T pushedValue)
        {
            elementsList.Add(pushedValue);
        }
    }
}