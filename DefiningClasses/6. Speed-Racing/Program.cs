using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Car> carsList = new Dictionary<string,Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Car currentCar = new Car(input[0],double.Parse(input[1]),double.Parse(input[2]));
                carsList.Add(input[0],currentCar);
            }
            string input2 = Console.ReadLine();
            while (input2!="End")
            {
                string[] command = input2.Split();
                if (carsList.ContainsKey(command[1]))
                {
                    Car current = carsList[command[1]];
                    if (current.CanMove(double.Parse(command[2])))
                    {
                        current.ReduceFuel(double.Parse(command[2]));
                    }
                    else
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }
                }
                input2 = Console.ReadLine();
            }
            foreach (var car in carsList)
            {
                Console.WriteLine($"{car.Value.Model} {car.Value.FuelAmount:f2} {car.Value.Travelleddistance}");
            }
        }
    }
}
