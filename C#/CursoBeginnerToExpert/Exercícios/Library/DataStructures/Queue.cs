using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class Queue<T>
    {
        private List<T> Values;
        public int Start { get; private set; }
        public int Count { get => Values.Count; }

        public Queue()
        {
            Values = new List<T>();
            Start = 0;
        }

        public bool IsEmpty() => Values.Count == 0;

        public void Enqueue(T element) => Values.Add(element);

        public T Dequeue()
        {
            T element = Values[Start];
            Values.RemoveAt(Start);
            Start = IsEmpty() ? 0 : Start + 1;

            return element;
        }
    }
}
