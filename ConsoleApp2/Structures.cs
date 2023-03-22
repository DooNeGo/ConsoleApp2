using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class LinkedList<T>
    {
        private Node<T>? head;
        private Node<T>? tail;
        private int count;

        public void Add(T value)
        {
            if (head is null)
            {
                head = new Node<T> { Value = value };
                tail = head;
            }
            else
            {
                tail!.Next = new Node<T> { Value = value };
                tail = tail.Next;
            }
            count++;
        }

        public T[] ToArray()
        {
            var cur = head;
            T[] result = new T[count];
            int ind = 0;
            while (cur is not null)
            {
                result[ind++] = cur.Value;
                cur = cur.Next;
            }
            return result;
        }

        private class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }
        }
    }

    public class Tree<T>
    {
        private Node<T>? root;

        private class Node<T>
        {
            public T Value { get; set; }
            public Node<T>[] Children { get; set; }
        }
    }
}
