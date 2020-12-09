using System;
using System.IO;
using System.Text.RegularExpressions;

namespace EvenLines
{
    class Program
    {
        static void Main()
        {
            
            using (StreamReader reader = new StreamReader($"../../../text.txt"))
            {
                
                int counter = 0;
                string output= reader.ReadLine();
                char[] charsForReplacement = new char[] {'-', ',', '.', '!', '?'};
                while (output != null)
                {
                    if (counter % 2 == 0)
                    {
                        Regex pattern = new Regex("[-,.!?]");
                        output = pattern.Replace(output,"@");
                        string[] lineArr = output.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        for (int i = lineArr.Length-1; i>=0; i--)
                        {
                            Console.Write($"{lineArr[i]} ");
                        }
                        Console.WriteLine();
                    }
                    output = reader.ReadLine();
                    counter++;
                }

            }
        }
    }
}
