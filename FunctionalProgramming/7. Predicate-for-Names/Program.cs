using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateforNames
{
    class Program
    {
        private static Func<object, object, List<string>> namesEqualsN;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            List<string> resultNames = new List<string>();
           
            Func<List<string>, int, List<string>> namesEqualsN = (namesList, n) =>
                {
                    List<string> result = new List<string>();
                    foreach (var item in namesList.Where(name=>name.Length<=n))
                    {
                        result.Add(item);
                    }
                    return result;
                };
            Action<List<string>> PrintName = message => Console.WriteLine(string.Join(Environment.NewLine, message));
            resultNames = namesEqualsN(names.ToList(), n);
            PrintName(resultNames);
        }
    }
}
