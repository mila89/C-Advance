using System;

namespace ImplementiningCustomStack
{
    class StartUp
    {
        static void Main()
        {
            CustomStack myStack = new CustomStack();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            myStack.Push(5);

            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Peek());
            Console.WriteLine();
            myStack.ForEach(Console.WriteLine);
        }
    }
}
