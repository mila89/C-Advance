using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PredicateParty
{
    class Program
    {
        static void Main()
        {
            List<string> invitedPeople = Console.ReadLine().Split().ToList();
            string command = Console.ReadLine();
            Func<List<string>, string, string, List<string>> removePeople = (list, command1, command2) =>
             {
                 if (command1 == "StartsWith")
                 {
                     list.RemoveAll(name => name.StartsWith(command2));
                 }
                 else if (command1 == "EndsWith")
                 {
                     list.RemoveAll(name => name.EndsWith(command2));
                 }
                 else if (command1 == "Length")
                 {
                     list.RemoveAll(name => name.Length == int.Parse(command2));
                 }
                 return list;
             };

            Func<List<string>, string, string, List<string>> doublePeople = (list, command1, command2) =>
            {
                List<string> result = new List<string>();
                if (command1 == "StartsWith")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        result.Add(list[i]);
                        if (list[i].StartsWith(command2))
                            result.Add(list[i]);
                    }
                }
                else if (command1 == "EndsWith")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        result.Add(list[i]);
                        if (list[i].EndsWith(command2))
                            result.Add(list[i]);
                    }  
                }
                else if (command1 == "Length")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        result.Add(list[i]);
                        if (list[i].Length==int.Parse(command2))
                            result.Add(list[i]);
                    }
                }
                return result;
            };

            Action<List<string>> PrintPeopleParty = message =>
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < message.Count; i++)
                {
                    if (i == message.Count - 1)
                        sb.Append(message[i]);
                    else
                        sb.Append(message[i] + ", ");
                }
                
                if (sb.Length==0)
                    Console.WriteLine("Nobody is going to the party!");
                else
                    Console.WriteLine(sb+ " are going to the party!");
            };

            while (command!="Party!")
            {
                string[] commandArr = command.Split();
                switch (commandArr[0])
                {
                    case "Remove":
                        invitedPeople = removePeople(invitedPeople, commandArr[1], commandArr[2]);
                        break;
                    case "Double":
                        invitedPeople = doublePeople(invitedPeople, commandArr[1], commandArr[2]);
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            PrintPeopleParty(invitedPeople);
        }
    }
}
