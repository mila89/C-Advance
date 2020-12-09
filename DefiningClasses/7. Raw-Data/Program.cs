using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    enum Type { fragile, flamble }
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Engine engine = new Engine(int.Parse(input[1]),int.Parse(input[2]));
                Cargo cargo = new Cargo(int.Parse(input[3]),input[4]);
                List<Tire> tires = new List<Tire>();
                for (int j = 5; j < 13; j+=2)
                {
                    Tire currentTire = new Tire(double.Parse(input[j]),int.Parse(input[j+1]));
                    tires.Add(currentTire); 
                }
                Car currentCar = new Car(input[0],engine,cargo,tires);
                cars.Add(currentCar);
            }
            string type = Console.ReadLine();
            if (type == "fragile")
            {
                foreach (var car in cars.Where(c => c.Cargo.Type == "fragile"))
                {
                    car.Tires = car.Tires.Where(t => t.Pressure < 1).ToList();
                    if (car.Tires.Count>0)
                        Console.WriteLine(car.Model);
                }
            }
            else if (type == "flamable")
            {
                foreach (var car in cars.Where(c=>c.Cargo.Type=="flamable").Where(c=>c.Engine.Power>250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
        
    }
}
