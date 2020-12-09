using System;

namespace ThreeupleType
{
    public class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Threeuple<string, string, string> threple1;
            if (input.Length == 5)
            {
                threple1 = new Threeuple<string, string, string>($"{input[0]} {input[1]}", input[2], $"{input[3]} {input[4]}");
            }
            else
            {
                threple1 = new Threeuple<string, string, string>($"{input[0]} {input[1]}", input[2], input[3]);
            }
            Console.WriteLine(threple1);

            input = Console.ReadLine().Split();
            Threeuple<string, int, bool> threple2;
            bool isDrunk = input[2] == "drunk" ? true : false;
            threple2 = new Threeuple<string, int, bool>(input[0], int.Parse(input[1]), isDrunk);            
            Console.WriteLine(threple2);

            input = Console.ReadLine().Split();
            Threeuple<string, double, string> tuple3 = new Threeuple<string, double, string>(input[0], double.Parse(input[1]), input[2]);
            Console.WriteLine(tuple3);
            
        }
    }
}
