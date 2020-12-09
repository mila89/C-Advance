using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseandExclude
{
    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int num=int.Parse(Console.ReadLine());
            Array.Reverse(input);
            Action<List<int>> PrintNums = message => Console.WriteLine(string.Join(" ", message));
            Func<int[], int, List<int>> excludeFunc = (array, num) => 
            {
                List<int> result = new List<int>();
                result = array.Where(n => n % num != 0).ToList();
                return result;
            
            };
            PrintNums(excludeFunc(input, num));
        }
    }
}
