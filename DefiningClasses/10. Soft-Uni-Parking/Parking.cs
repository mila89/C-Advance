using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        // private List<Car> addedCars;
        private int capacity;

        public Parking(int capacity)
        {
            AddedCars = new List<Car>();
            this.capacity = capacity;
        }


        public List<Car> AddedCars
        {
            get;
            set;
        }
        /*  public int Capacity
          {
              get { return capacity; }
              set { Capacity = value; }
          }*/

        public int Count
        {
            get { return AddedCars.Count; }
        }
        public string AddCar(Car car)
        {
            for (int i = 0; i < AddedCars.Count; i++)
            {
                if (AddedCars[i].RegistrationNumber == car.RegistrationNumber)
                    return "Car with that registration number, already exists!";
            }
            if (AddedCars.Count == capacity)
                return "Parking is full!";
            else
            {
                AddedCars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string RegistrationNumber)
        {
            bool carExist = false;
            for (int i = 0; i < AddedCars.Count; i++)
            {
                if (AddedCars[i].RegistrationNumber == RegistrationNumber)
                {
                    AddedCars.RemoveAt(i);
                    carExist = true;
                    break;
                }
            }
            if (!carExist)
                return "Car with that registration number, doesn't exist!";
            else
                return $"Successfully removed {RegistrationNumber}";
        }

        public Car GetCar(string RegistrationNumber)
        {
            for (int i = 0; i < AddedCars.Count; i++)
            {
                if (AddedCars[i].RegistrationNumber == RegistrationNumber)
                    return AddedCars[i];
            }
            return null;
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            for (int i = 0; i < RegistrationNumbers.Count; i++)
            {
                foreach (var car in AddedCars)
                {
                    if (car.RegistrationNumber == RegistrationNumbers[i])
                        AddedCars.Remove(car);
                }
            }
        }
    }
}
