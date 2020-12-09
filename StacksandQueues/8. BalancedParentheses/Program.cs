using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> stackFirst = new Stack<char>();
            Stack<char> stackSecond = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                stackFirst.Push(input[i]);
            }
            char temp1;
            stackSecond.Push(stackFirst.Pop());
            bool isInvalid = false;
            while (stackFirst.Count > 0)
            {
                temp1 = stackFirst.Pop();
                stackFirst.Any();
                char temp2=' ';
                if (stackSecond.Count > 0)
                    temp2 = stackSecond.Peek();
                else
                {
                    isInvalid = true;
                    break;
                }
                if (!IsPair(temp1, temp2))
                {
                    stackSecond.Push(temp1);
                }
                else
                    stackSecond.Pop();
            }

            if (stackSecond.Count>0 || isInvalid)
                Console.WriteLine("NO");
            else
                Console.WriteLine("YES");

            static bool IsPair(char ch1,char ch2)
            {
                if (ch1 == '{')
                {
                    if (ch2 == '}')
                        return true;
                }
                else if (ch1 == '[')
                {
                    if (ch2 == ']')
                        return true;
                }
                else if (ch1 == '(')
                {
                    if (ch2 == ')')
                        return true;
                }
                return false;
            }
        }
    }
}
