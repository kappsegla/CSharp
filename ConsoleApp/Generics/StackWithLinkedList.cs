using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp.Generics
{
    public class StackUsingLinkedList
    {
        // A linked list node 
        private class Node
        {
            public int data;

            public Node link;
        }

        // create global top reference variable 
        Node head;

        // Constructor 
        public StackUsingLinkedList()
        {
            this.head = null;
        }

        // Utility function to add 
        // an element x in the stack 
        // insert at the beginning 
        public void Push(int x)
        {
            // create new node temp and allocate memory 
            Node temp = new Node();

            // initialize data into temp data field 
            temp.data = x;

            // put top reference into temp link 
            temp.link = head;

            // update top reference 
            head = temp;
        }

        // Utility function to check if 
        // the stack is empty or not 
        public bool IsEmpty()
        {
            return head == null;
        }

        // Utility function to return 
        // top element in a stack without removing it
        public int Peek()
        {
            // check for empty stack 
            if (!IsEmpty())
            {
                return head.data;
            }
            else
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }

        // Utility function to pop top element from the stack 
        public int Pop() // remove at the beginning 
        {
            // check for stack underflow 
            if (head == null)
            {
                //return default(T)
                throw new InvalidOperationException("Stack is empty");
            }

            int temp = head.data;
            
            // update the top pointer to
            // point to the next node 
            head = (head).link;

            return temp;

        }
    }
}