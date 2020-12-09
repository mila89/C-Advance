using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensorOdds
{
    class Program
    {
        public static object Select { get; private set; }

        static void Main()
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int low = range[0];
            int up = range[1];
            List<int> output = new List<int>();
            string command = Console.ReadLine();          
            
            Func<int, int, List<int>> sequence = (start,end) =>
            {
                List<int> result = new List<int>();
                for (int i = low; i <= up; i++)
                {
                    result.Add(i);
                }
                return result;
            };

            output = sequence(low, up);
            Func<int,bool> evenPredicate = n => n % 2 == 0;
            Func<int,bool> oddPredicate = n => n % 2 != 0;
            
          
            Func<List<int>, string, List<int>> func = (list, command) =>
                {
                    List<int> resultList = new List<int>();
                    if (command=="even")
                       resultList = list.Where(n => n % 2 == 0).ToList();
                    else if (command=="odd")
                        resultList = list.Where(n => n % 2 != 0).ToList();
                    return resultList;
                };
            Action<List<int>> PrintResult = message => Console.Write(string.Join(" ", message));
            output = func(output, command);
            PrintResult(output);


            //Console.WriteLine(String.Join().output.Where(n => n % 2 == 0));


            /*  Func<int, int, string, List<int>> func = n =>n
                  {
                      List<int> result = new List<int>();
                      return result;
                  };*/
        }
    }
}
