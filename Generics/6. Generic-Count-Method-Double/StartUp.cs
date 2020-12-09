using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<double> list = new List<double>();
            for (int i = 0; i < n; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }
            Box<double> box = new Box<double>(list);
            double value = double.Parse(Console.ReadLine());
            Console.WriteLine(box.CountElements(list, value));
        }
    }
}
