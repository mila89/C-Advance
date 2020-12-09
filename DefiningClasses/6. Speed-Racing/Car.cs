using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car()
        {
            Travelleddistance = 0;
        }
        public Car(string model,double fuel,double consumption):this()
        {
            Model = model;
            FuelAmount = fuel;
            FuelConsumptionPerKilometer = consumption;
        }
        public string Model { get; set; }
        public double FuelAmount{ get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double Travelleddistance { get; set; }
        public bool CanMove(double distance)
        {
            if (distance * FuelConsumptionPerKilometer > FuelAmount)
                return false;
            else
                return true;
        }
        public void ReduceFuel(double distance)
        {
            FuelAmount -= distance * FuelConsumptionPerKilometer;
            Travelleddistance += distance;
        }
    }
}
