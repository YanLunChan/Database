using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms.Linked_List
{
    public class LinkedList<T>
    {
        Node<T> head, tail;
        private long size;

        //set first value to whatever the value is
        public LinkedList(T val)
        {
            head = new Node<T>(val);
            tail = head;
            size = 1;
        }
        public void Append(T val)
        {
            Node<T> newTail = new Node<T>(val);
            tail.SetNext(newTail);
            tail = newTail;
            size++;
        }
        public T Get(int position)
        {
            Node<T> itr = head;
            int idx = 0;
            while (idx++ < position && itr.GetNext() != null)
            {
                itr = itr.GetNext();
            }
            return itr.GetValue();
        }
        public long GetSize() { return size; }
        public void Remove(int position)
        {
            //check if position is bigger than the size
            if (position > size)
            {
                Console.WriteLine("position DNE");
                return;
            }

            Node<T> itr = head;
            int idx = 0;
            // if position is not tails change position to previous node
            if (position < size)
                position--;
            while (idx++ < position && itr.GetNext() != null)
            {
                itr = itr.GetNext();
            }
            if (itr == tail)
            {
                itr = null;
                tail = itr;
                Console.WriteLine($"Removed position {position}");

            }
            else
            {
                //if head then set head to next node
                if (itr == head)
                    head = itr.GetNext();
                else
                    itr.SetNext(itr.GetNext().GetNext());
                Console.WriteLine($"Removed position {position + 1}");
            }
            size -= 1;
        }
    }

    public class Node<T>
    {
        private T value;
        private Node<T> next;

        public Node() => next = null;
        public Node(T val)
        {
            value = val;
            next = null;
        }
        public T GetValue() { return value; }
        public void SetValue(T val) => value = val;
        public Node<T> GetNext() { return next; }
        public void SetNext(Node<T> n) { next = n;}
    }
}
