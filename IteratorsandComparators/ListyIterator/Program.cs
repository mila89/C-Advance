using System;
using System.Collections.Generic;

namespace ListyIterator
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<string> inputList = new List<string>();
            for (int i = 1; i < input.Length; i++)
            {
                inputList.Add(input[i]);
            }
            ListyIterator<string> list;
            if (inputList.Count == 0)
                list = new ListyIterator<string>();
            else
                 list = new ListyIterator<string>(inputList);
            input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (input[0]!="END")
            {
                if (input[0] == "Move")
                {
                    Console.WriteLine(list.Move()); 
                }
                else if (input[0] == "HasNext")
                {
                    Console.WriteLine(list.HasNext()); 
                }
                else if (input[0] == "Print")
                    list.Print();
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
