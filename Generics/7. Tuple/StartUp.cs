using System;

namespace TupleType
{
    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, string> tuple;
            if (input.Length == 3)
            {
                tuple = new Tuple<string, string>($"{input[0]} {input[1]}", input[2]);
            }
            else
            {
                tuple = new Tuple<string, string>(input[0], input[1]);
            }

            input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, int> tuple2 = new Tuple<string, int>(input[0], int.Parse(input[1]));
            input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Tuple<int,double> tuple3 = new Tuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));
            Console.WriteLine(tuple.ToString());
            Console.WriteLine(tuple2.ToString());
            Console.WriteLine(tuple3.ToString());
        }
    }
}
