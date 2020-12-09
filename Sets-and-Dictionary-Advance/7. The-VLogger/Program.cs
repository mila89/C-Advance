using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(" ");
            List<Vlogger> vLogger = new List<Vlogger>();
            HashSet<string> existedVlogers = new HashSet<string>();
            while (input[0]!="Statistics")
            {
                if (input[1] == "joined")
                {
                    if (!existedVlogers.Contains(input[0])) // doesn't exist
                    {
                        Vlogger currentVloger = new Vlogger();
                        currentVloger.Name = input[0];
                        currentVloger.Followers = new List<string>();
                        currentVloger.Following = new List<string>();
                        vLogger.Add(currentVloger);
                        existedVlogers.Add(input[0]);
                    }
                }
                else if (input[1] == "followed")
                { 
                    if ((input[0]!=input[2])&&(existedVlogers.Contains(input[0]) && existedVlogers.Contains(input[2])))
                    {
                       // Vlogger currentVloger = new Vlogger();
                        int index= FindVloger(vLogger,input[2]);
                        if (!vLogger[index].Followers.Contains(input[0]))
                        {
                            vLogger[index].Followers.Add(input[0]);
                            index = FindVloger(vLogger, input[0]);
                            vLogger[index].Following.Add(input[2]);
                        }
                    }
                }
                input = Console.ReadLine().Split(" ");
            }
            vLogger = vLogger.OrderByDescending(x => x.Followers.Count).ThenBy(x => x.Following.Count).ToList();
            Console.WriteLine($"The V-Logger has a total of {vLogger.Count} vloggers in its logs.");
            Console.WriteLine($"1. {vLogger[0].Name} : {vLogger[0].Followers.Count} followers, " +
                              $"{vLogger[0].Following.Count} following");
            vLogger[0].Followers.Sort();
            for (int i = 0; i < vLogger[0].Followers.Count; i++)
            {
                Console.WriteLine($"*  {vLogger[0].Followers[i]}");
            }
            for (int i = 1; i < vLogger.Count; i++)
            {
                Console.WriteLine($"{i+1}. {vLogger[i].Name} : {vLogger[i].Followers.Count} followers, " +
                             $"{vLogger[i].Following.Count} following");
            }
        }

       static int FindVloger(List<Vlogger> vloggers, string name)
        {
            for (int i = 0; i < vloggers.Count; i++)
            {
                if (vloggers[i].Name == name)
                    return i;
            }
            return -1;
        }
    }

    class Vlogger
    {
        public string Name { get; set; }
        public List<string> Followers { get; set; }
        public List<string> Following { get; set; }
    }
}
