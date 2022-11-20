using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class LinkedList<T>
    {
        public class LinkedListNode
        {
            public T data;
            public LinkedListNode next;

            public LinkedListNode(T data, LinkedList<T>.LinkedListNode next)
            {
                this.data = data;
                this.next = next;
            }
        }

        private LinkedListNode first = null;

        public void Add(T element)
        {
            if(first == null)
                first = new LinkedListNode(element, null);
            else
            {
                LinkedListNode curNode = first;
                for(curNode = first; curNode != null; curNode = curNode.next)
                {
                    if(curNode.next == null)
                    {
                        curNode.next = new LinkedListNode(element, null);
                        break;
                    }
                }
            }
        }

        public bool Remove(T element)
        {
            return false;
        }

        public int Count()
        {
            LinkedListNode curNode = first;
            int count = 0;

            for (curNode = first; curNode != null; curNode = curNode.next)
                count++;

            return count;
        }

        public bool IsEmpty() => first == null;

        public T GetElementAt(int index)
        {
            LinkedListNode curNode = first;

            for (int i = 0; i < index; i++)
                curNode = curNode.next;


            return curNode.data;
        }

        public int GetIndex(T element)
        {
            LinkedListNode curNode = first;
            int index = 0;

            for (curNode = first; curNode != null; curNode = curNode.next)
            {
                if (curNode.data.Equals(element))
                    return index;

                index++;
            }

            return -1;
        }
    }
}
