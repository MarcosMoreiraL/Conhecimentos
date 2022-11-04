using System;

namespace CursoUdemyBeginnerToExpert
{
    internal class Teste
    {
        static void Main(string[] args)
        {
            Library.DataStructures.LinkedList<int> myList = new Library.DataStructures.LinkedList<int>();

            myList.Add(0);
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);

            Console.WriteLine("Count: " + myList.Count());

            for (int i = 4; i > -1; i--)
            {
                Console.WriteLine(myList.GetIndex(i));
            }
        }
    }
}