using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                Person currentPerson = new Person(input[0], int.Parse(input[1]));
                family.ListOfPeople.Add(currentPerson);
            }
            family.ListOfPeople = family.ListOfPeople.OrderBy(p => p.Name).Where(p => p.Age > 30).ToList();
            foreach (var item in family.ListOfPeople)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
            
        }
    }
}
