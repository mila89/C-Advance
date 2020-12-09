using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main()
        {
            Func<string, int> myIntParse = n => int.Parse(n);
            int[] input = Console.ReadLine().Split().Select(myIntParse).ToArray();
            Func<int[], int> getSmallest = n =>
            {
                int result = int.MaxValue;
                foreach (var item in n)
                {
                    if (item < result)
                        result = item;
                }
                return result;
            };
            Console.WriteLine(getSmallest(input));

            
        }
    }
}
