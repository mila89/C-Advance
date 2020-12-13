using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    class Clinic
    {
        private List<Pet> data;
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            data = new List<Pet>();
        }

        public int Count { get=> data.Count; }
        public int Capacity { get; set; }

        public void Add(Pet currentPet)
        {
            if (data.Count < this.Capacity)
                data.Add(currentPet);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The clinic has the following patients:");
            foreach (var item in data)
            {
                sb.AppendLine($"Pet {item.Name} with owner: {item.Owner}");
            }
            return sb.ToString();
        }
        public bool Remove(string name)
        {
            Pet foundedPet = PetExist(name);
            if (foundedPet != null)
            {
                data.Remove(foundedPet);
                return true;
            }
            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Name == name && data[i].Owner==owner)
                    return data[i];
            }
            return null;
        }

        public Pet GetOldestPet()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }
        private Pet PetExist(string name)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Name == name)
                    return data[i];
            }
            return null;
        }
    }
}
