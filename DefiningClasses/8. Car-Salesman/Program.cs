using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engineList = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                string[] inputEngine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                Engine engine;
                if (inputEngine.Length == 2)
                {
                    engine = new Engine(inputEngine[0], int.Parse(inputEngine[1]));
                }
                else if (inputEngine.Length == 3)
                {
                    if (char.IsLetter(inputEngine[2][0]))
                        engine = new Engine(inputEngine[0], int.Parse(inputEngine[1]), inputEngine[2]);
                    else
                        engine = new Engine(inputEngine[0], int.Parse(inputEngine[1]), int.Parse(inputEngine[2]));
                }
                else
                {
                    engine = new Engine(inputEngine[0], int.Parse(inputEngine[1]),
                                            int.Parse(inputEngine[2]), inputEngine[3]);
                }
                engineList.Add(engine);
            }
            int m = int.Parse(Console.ReadLine());
            List<Car> carList = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                string[] inputCar = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                List<Engine> tempList = engineList.Where((en => en.Model == inputCar[1])).ToList();
                Car currentCar;
                if (inputCar.Length == 2)
                {
                    currentCar = new Car(inputCar[0], tempList[0]);
                }
                else if (inputCar.Length == 3)
                {
                    if (char.IsLetter(inputCar[2][0]))
                        currentCar = new Car(inputCar[0], tempList[0], (inputCar[2]));
                    else
                        currentCar = new Car(inputCar[0], tempList[0],int.Parse(inputCar[2]));
                }
                else //(inputCar.Length == 4)
                {
                    currentCar = new Car(inputCar[0], tempList[0], int.Parse(inputCar[2]),inputCar[3]);
                }
                carList.Add(currentCar);
            }
            foreach (var car in carList)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                if (car.Engine.Displacement==0)
                    Console.WriteLine($"    Displacement: n/a");
                else
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                if (car.Engine.Efficiency == null)
                    Console.WriteLine($"    Efficiency: n/a");
                else
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                if (car.Weight == 0)
                    Console.WriteLine($"  Weight: n/a");
                else
                    Console.WriteLine($"  Weight: {car.Weight}");
                if (car.Color == null)
                    Console.WriteLine($"  Color: n/a");
                else
                    Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
