using System;
using System.Collections.Generic;

namespace GenericBoxofString
{
    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Box<string> currentBox = new Box<string>(Console.ReadLine());
                Console.WriteLine(currentBox.ToString());
            }
        }
    }
}
