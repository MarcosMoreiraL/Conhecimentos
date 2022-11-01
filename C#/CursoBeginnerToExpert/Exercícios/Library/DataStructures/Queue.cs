using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class Queue
    {
        private List<int> Values;
        public int Start { get; private set; }
        public int Count { get => Values.Count; }

        public Queue()
        {
            Values = new List<int>();
            Start = 0;
        }

        public bool IsEmpty() => Values.Count == 0;

        public void Enqueue(int element) => Values.Add(element);

        public int Dequeue()
        {
            int element = Values[Start];
            Values.RemoveAt(Start);
            Start = IsEmpty() ? 0 : Start + 1;

            return element;
        }
    }
}
