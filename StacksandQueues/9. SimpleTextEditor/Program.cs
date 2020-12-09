using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();
            for (int i = 1; i <= n; i++)
            {
                string[] command = Console.ReadLine().Split(" ");
                
                switch (command[0])
                {
                    case "1":
                        //append
                        if (stack.Count > 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append(stack.Peek()+ command[1]);
                            //sb.Append();
                            stack.Push(sb.ToString());
                        }
                        else
                            stack.Push(command[1]);
                        break;
                    case "2":
                        //erese
                        if (stack.Count > 0)
                        {
                            string temp = stack.Peek();
                            string subStr = temp.Substring(0, temp.Length - int.Parse(command[1]));
                            stack.Push(subStr);
                        }
                        break;
                    case "3":
                        //return index
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Peek()[int.Parse(command[1]) - 1]);
                        }
                        break;
                    case "4":
                        // undoes
                        if (stack.Count>0)
                            stack.Pop();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
