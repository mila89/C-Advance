using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int windowDuration = int.Parse(Console.ReadLine());
            Queue<string> carsQueue = new Queue<string>();
            Queue<string> carsInCrossroad = new Queue<string>();
            string input = Console.ReadLine();
            int countCars = 0; // cars that have passed succesefully
            char hitChar = ' '; // the point where the car has been hit
            string hitCar = " "; // the name of the car that has been hit
            bool IsCrashed = false;
            while (input!="END")
            {
                if (input != "green")
                {
                    carsQueue.Enqueue(input);
                }
                else
                {
                    int fullDuration = greenDuration + windowDuration;
                    int tempGreenDuration = greenDuration;
                    while (tempGreenDuration > 0 && carsQueue.Count>0)
                    {
                        string tempCar = carsQueue.Peek();
                        if (tempGreenDuration>0)
                        {
                            carsInCrossroad.Enqueue(tempCar);
                            carsQueue.Dequeue();
                            tempGreenDuration -= tempCar.Length;
                        }
                    }
                    while (fullDuration>0 && carsInCrossroad.Count>0)
                    {
                        string carOnRoad =carsInCrossroad.Peek();
                        if (fullDuration - carOnRoad.Length >= 0)
                        {
                            carsInCrossroad.Dequeue();
                            fullDuration -= carOnRoad.Length;
                            countCars++;
                        }
                        else
                        {
                            hitChar = carOnRoad[fullDuration];
                            fullDuration = 0;
                            IsCrashed = true;
                            hitCar = carOnRoad;
                        }
                    }
                }
                if (IsCrashed)
                    break;
                else
                    input = Console.ReadLine();
            }
            if (carsInCrossroad.Count == 0)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{countCars} total cars passed the crossroads.");
            }
            else
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{hitCar} was hit at {hitChar}.");
            }
        }
    }
}
