using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class Stack
    {
        private List<int> Values;
        public int Count { get => Values.Count; }

        public int Top { get; private set; }

        public Stack()
        {
            Values = new List<int>();
            Top = -1;
        }

        public bool IsEmpty() => Top == -1;

        public void Push(int element)
        {
            Values.Add(element);
            Top++;
        }

        public int Pop()
        {
            int element = Values[Top];
            Values.RemoveAt(Top);

            return element;
        }
    }
}
z