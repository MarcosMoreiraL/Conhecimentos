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
        public int Count { get => Values.Count; }

        public Queue()
        {
            Values = new List<T>();
        }

        public bool IsEmpty() => Values.Count == 0;

        public void Enqueue(T element) => Values.Add(element);

        public T Dequeue()
        {
            T element = Values.First();
            Values.RemoveAt(0);

            return element;
        }
    }
}
