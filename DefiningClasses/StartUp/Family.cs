using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            ListOfPeople = new List<Person>();
        }
        public List<Person> ListOfPeople { get; set; }

        public void AddMember(Person member)
        {
            this.ListOfPeople.Add(member);
        }

        public Person GetOldestMember()
        {
            ListOfPeople = ListOfPeople.OrderByDescending(p => p.Age).ToList();
            return ListOfPeople[0];
        }
    }
}
