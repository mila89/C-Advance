using System;
using System.Collections.Generic;
using System.Linq;

namespace ListofPredicates
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> numbersList = new List<int>();
            
            Func<List<int>, int, bool> divisible = (arr,n) =>
            {
                bool result = true;   
                for (int i = 0; i < arr.Count; i++)
                {
                    if (!(n % arr[i] == 0))
                        return false;
                }
                
                return result;
            };

            Func<int, int[], List<int>> findNumbers = (n, arr) =>
               {
                   List<int> result = new List<int>();
                   for (int i = 1; i <=n; i++)
                   {
                       if (divisible(arr.ToList(),i))
                            result.Add(i);
                   }
                   return result;
               };

            Action<List<int>> PrintNums = message => Console.WriteLine(string.Join(" ", message));
            numbersList = findNumbers(n, dividers);
            PrintNums(numbersList);
        }
    }
}
