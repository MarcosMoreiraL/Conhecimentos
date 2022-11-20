using System;

namespace CursoUdemyBeginnerToExpert
{
    internal class Teste
    {
        static void Main(string[] args)
        {
            Library.DataStructures.DoublyLinkedList<int> myList = new Library.DataStructures.DoublyLinkedList<int>();

            myList.Add(0);
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);

            Console.WriteLine("Count: " + myList.Count());
            Console.WriteLine(myList.ToString());
        }
    }
}