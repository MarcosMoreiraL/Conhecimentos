using System;

namespace CursoUdemyBeginnerToExpert
{
    internal class Teste
    {
        static void Main(string[] args)
        {
            Library.DataStructures.Stack<int> myStack = new Library.DataStructures.Stack<int>();

            myStack.Push(0);
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(myStack.Pop());
            }
        }
    }
}