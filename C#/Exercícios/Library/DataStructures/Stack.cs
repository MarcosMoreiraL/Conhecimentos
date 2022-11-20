using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class Stack<T>
    {
        private List<T> Values;
        public int Count { get => Values.Count; }

        public int Top { get; private set; }

        public Stack()
        {
            Values = new List<T>();
            Top = -1;
        }

        public bool IsEmpty() => Top == -1;

        public void Push(T element)
        {
            Values.Add(element);
            Top++;
        }

        public T Pop()
        {
            T element = Values[Top];
            Values.RemoveAt(Top);
            Top--;

            return element;
        }
    }
}