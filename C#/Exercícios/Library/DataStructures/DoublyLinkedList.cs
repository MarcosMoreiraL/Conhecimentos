using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class DoublyLinkedList<T>
    {
        public class DoublyLinkedListNode
        {
            public T data;
            public DoublyLinkedListNode next;
            public DoublyLinkedListNode previous;

            public DoublyLinkedListNode(T data, DoublyLinkedList<T>.DoublyLinkedListNode next, DoublyLinkedList<T>.DoublyLinkedListNode previous)
            {
                this.data = data;
                this.next = next;
                this.previous = previous;
            }
        }

        private DoublyLinkedListNode first = null;
        private DoublyLinkedListNode last = null;

        public void Add(T data)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(data, null, null);

            if (IsEmpty())
            {
                newNode.next = newNode;
                newNode.previous = newNode;
                first = newNode;
                last = newNode;
            }
            else
            {
                DoublyLinkedListNode temp = first;
                while(temp.next != first)
                    temp = temp.next;

                first.previous = newNode;
                temp.next = newNode;
                newNode.previous = temp;
                newNode.next = first;
                last = newNode;
            }
        }

        public void Add(DoublyLinkedListNode newNode)
        {
            if (IsEmpty())
            {
                newNode.next = newNode;
                newNode.previous = newNode;
                first = newNode;
                last = newNode;
            }
            else
            {
                DoublyLinkedListNode temp = first;
                while (temp.next != first)
                    temp = temp.next;

                first.previous = newNode;
                temp.next = newNode;
                newNode.previous = temp;
                newNode.next = first;
                last = newNode;
            }
        }

        public bool Remove(T data)
        {
            if (IsEmpty())
                throw new Exception("Empty List!");

            if (first.data.Equals(data))
            {
                if (Count() == 1)
                {
                    first = null;
                    return true;
                }
                else
                {
                    DoublyLinkedListNode currentNode = first, prevNode = first.previous;
                    first = currentNode.next;
                    prevNode.next = currentNode.next;
                    first.previous = prevNode;
                    return true;
                }
            }
            else
            {
                DoublyLinkedListNode currentNode = first.next, prevNode = currentNode.previous;
                while(currentNode != first && !currentNode.data.Equals(data))
                {
                    currentNode = currentNode.next;
                    prevNode = currentNode.previous;
                }

                if (currentNode == first)
                    throw new Exception("The element does not exist!");

                prevNode.next = currentNode.next;
                currentNode.next.previous = prevNode;
                return true;

            }

            return false;
        }

        public bool Remove(DoublyLinkedListNode element)
        {
            return false;
        }

        public int Count()
        {
            if (IsEmpty())
                return 0;

            int count = 1;
            DoublyLinkedListNode temp = first;

            while (temp.next != first)
            {
                temp = temp.next;
                count++;
            }

            return count;
        }

        public bool IsEmpty() => first == null;

        public DoublyLinkedListNode GetElementAt(int index)
        {
            DoublyLinkedListNode temp = first;
            int count = 0;

            while (temp.next != first)
            {
                if (count == index)
                    return temp;

                temp = temp.next;
                count++;
            }

            return null;
        }

        public int GetIndex(T data)
        {
            DoublyLinkedListNode temp = first;
            int index = 0;

            while (temp.next != first)
            {
                if (temp.data.Equals(data))
                    return index;

                temp = temp.next;
                index++;
            }

            return -1;
        }

        public DoublyLinkedListNode GetFirst() => first;

        public DoublyLinkedListNode GetLast() => last;

        public string ToString(bool inOder = true)
        {
            if (IsEmpty())
                throw new Exception("Empty List!");

            string stringList = string.Empty;

            if (inOder)
            {
                DoublyLinkedListNode temp = first;
                do
                {
                    stringList += temp.data.ToString() + (temp != last ? ' ' : string.Empty);
                    temp = temp.next;
                }while(temp != first);
            }
            else
            {
                DoublyLinkedListNode temp = last;
                do
                {
                    stringList += temp.data.ToString() + (temp != first ? ' ' : string.Empty);
                    temp = temp.previous;
                } while (temp != last);
            }

            return stringList;
        }
    }
}
