using System;

namespace CursoUdemyBeginnerToExpert
{
    internal class Teste
    {
        static void Main(string[] args)
        {
            Library.DataStructures.Queue<int> myQueue = new Library.DataStructures.Queue<int>();

            myQueue.Enqueue(0);
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(myQueue.Dequeue());
            }
        }
    }
}