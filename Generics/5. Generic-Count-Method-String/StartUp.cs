using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            for (int i = 0; i < n; i++)
            {
               list.Add(Console.ReadLine());
            }
            Box<string> box = new Box<string>(list);
            string value = Console.ReadLine();
            Console.WriteLine(box.CountElements(list,value));
        }
    }
}
