using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Func<string, int, bool> isValid = (name, num) => name.ToCharArray().Select(ch => (int)ch).Sum() >= n;
            Func<string[], int, Func<string, int, bool>, string> firstValidName = (array, n, func) =>
                 {
                    return  array.FirstOrDefault(name => func(name, n));
                 };
            Console.WriteLine(firstValidName(names,n,isValid));
        }
    }
}
