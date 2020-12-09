using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    class Program
    {
        static void Main()
        {
            List<string> names = Console.ReadLine().Split().ToList();
            List<string> filterList = new List<string>();
            string input = Console.ReadLine();
            Func<List<string>, List<string>, List<string>> addFunc = (nameList, filters) =>
            {
                for (int i = 0; i < filters.Count; i++)
                {
                    string[] command = filters[i].Split(";");
                    switch (command[1])
                    {
                        case "Starts with":
                            nameList = nameList.Where(name => !name.StartsWith(command[2])).ToList();
                            break;
                        case "Ends with":
                            nameList = nameList.Where(name => !name.EndsWith(command[2])).ToList();
                            break;
                        case "Lenght":
                            nameList = nameList.Where(name => name.Length!=int.Parse(command[2])).ToList();
                            break;
                        case "Contains":
                            nameList = nameList.Where(name => !name.Contains(command[2])).ToList();
                            break;
                        default:
                            break;
                    }
                }               
                return nameList;
            };

            while (input != "Print")
            {                
                if (input.StartsWith("Add"))
                    filterList.Add(input.Substring(input.IndexOf(';')));
                else
                    filterList.Remove(input.Substring(input.IndexOf(';')));

                input = Console.ReadLine();
            }
            names = addFunc(names, filterList);
            Action<List<string>> PrintNames = message => Console.WriteLine(string.Join(" ", message));
            PrintNames(names);
        }
    }
}
