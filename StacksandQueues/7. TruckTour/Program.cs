using System;
using System.Collections.Generic;

namespace TruckTour
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<Pomp> listPomps = new Queue<Pomp>();
            Stack<Pomp> newListPomps = new Stack<Pomp>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                Pomp current = new Pomp();
                current.index = i;
                current.litters = int.Parse(input[0]);
                current.kilometers = int.Parse(input[1]);
                listPomps.Enqueue(current);
            }
            Pomp temp = new Pomp();
            int availability = 0;
            while (listPomps.Count>0)
            {
                temp = listPomps.Dequeue();
                if (temp.litters + availability >= temp.kilometers)
                {
                    newListPomps.Push(temp);
                    availability += temp.litters- temp.kilometers;
                }
                else
                    availability = 0;
            }
            temp = newListPomps.Pop();
            while (newListPomps.Count>0)
            {
                Pomp currentPomp = newListPomps.Pop();
                if (currentPomp.index + 1 == temp.index)
                    temp = currentPomp;
                else
                {
                    
                    break;
                }
            }
            Console.WriteLine(temp.index);
        }
    }

    class Pomp
    {
        public int index { get; set; }
        public int litters { get; set; }
        public int kilometers { get; set; }
    }

}
