using System;

namespace ConsoleApp.Generics
{
    public class Stack<T>
    {

        private class Node
        {
            public T data;

            public Node next;
        }

        private Node head = null;

        public void Push(T o)
        {
            var temp = new Node();
            temp.data = o;
            temp.next = head;

            head = temp;
        }

        public T Pop()
        {
            if( head == null)
                throw new InvalidOperationException();
            
            var temp = head;

            head = temp.next;

            return temp.data;
        }
    }
}