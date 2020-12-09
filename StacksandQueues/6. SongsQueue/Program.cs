using System;
using System.Collections;
using System.Collections.Generic;

namespace SongsQueue
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(", ");
            Queue<string> playList = new Queue<string>();
            for (int i = 0; i < input.Length; i++)
            {
                playList.Enqueue(input[i]);
            }

            while (playList.Count > 0)
            {
                string[] command = Console.ReadLine().Split(" ");
                switch (command[0])
                {
                    case "Add":
                        string song="";
                        for (int i = 1; i < command.Length; i++)
                        {
                            song=string.Concat(song, " ", command[i]);
                        }
                        string[] songs=playList.ToArray();
                        bool isContained = false;
                        foreach (var item in songs)
                        {
                            if (item == song.TrimStart())
                            {
                                Console.WriteLine($"{song} is already contained!");
                                isContained = true;
                                break;
                            }
                        }
                        if (!isContained)
                            playList.Enqueue(song.TrimStart());
                        break;
                    case "Show":
                        string[] showSongs = playList.ToArray();
                        for (int i = 0; i < showSongs.Length; i++)
                        {
                            if (i==showSongs.Length-1)
                                Console.Write(showSongs[i]);
                            else
                                Console.Write(showSongs[i]+", ");
                        }
                        Console.WriteLine();
                        break;
                    case "Play":
                        playList.Dequeue();
                        break;
                    default:
                        break;
                }
                if (playList.Count==0)
                    Console.WriteLine("No more songs!");
            }
        }
    }
}
