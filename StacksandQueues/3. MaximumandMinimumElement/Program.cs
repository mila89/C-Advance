using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximumandMinimumElement
{
    class Program
    {
        private static object stringBuilder;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> sequence = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                switch (input[0])
                {
                    case 1:
                        sequence.Push(input[1]);
                        break;
                    case 2:
                        if (sequence.Count>0)
                            sequence.Pop();
                        break;
                    case 3:
                        if (sequence.Count > 0)
                        {
                            List<int> temp = new List<int>();
                            while (sequence.Count > 0)
                            {
                                temp.Add(sequence.Pop());
                            }
                            int num = temp[0];
                            for (int j = 1; j < temp.Count; j++)
                            {
                                int number = temp[j];
                                if (num < number)
                                    num = number;
                            }
                            for (int j = temp.Count - 1; j >= 0; j--)
                            {
                                sequence.Push(temp[j]);
                            }
                            Console.WriteLine(num);
                        }
                        break;
                    case 4:
                        if (sequence.Count > 0)
                        {
                            List<int> tempList = new List<int>();
                            while (sequence.Count > 0)
                            {
                                tempList.Add(sequence.Pop());
                            }
                            int numMin = tempList[0];
                            for (int j = 1; j < tempList.Count; j++)
                            {
                                int number = tempList[j];
                                if (numMin > number)
                                    numMin = number;
                            }
                            for (int j = tempList.Count - 1; j >= 0; j--)
                            {
                                sequence.Push(tempList[j]);
                            }
                            Console.WriteLine(numMin);
                        }
                        break;
                    default:
                        break;
                }
            }

            List<int> result = new List<int>();
            while (sequence.Count>0)
            {
                result.Add(sequence.Pop());
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
