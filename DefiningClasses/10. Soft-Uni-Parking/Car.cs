﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public Car()
        {

        }
        public Car(string make, string model, int horsePower, string number)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = number;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: { this.Model}");
            sb.AppendLine($"HorsePower: { this.HorsePower}");
            sb.AppendLine($"RegistrationNumber: { this.RegistrationNumber}");
            return sb.ToString();
        }
    }
}