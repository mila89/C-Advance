using System;

namespace DefiningClasses
{
    class Program
    {
        static void Main()
        {
            Person pesho = new Person("Pesho",20);
            Console.WriteLine($"{pesho.Name} {pesho.Age}");
            Person gosho = new Person("Gosho", 18);
            Console.WriteLine($"{gosho.Name} {gosho.Age}");
            Person stamat = new Person("Stamat", 43);
            Console.WriteLine($"{stamat.Name} {stamat.Age}");

        }
    }
}
