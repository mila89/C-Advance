using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeupleType
{
    public class Threeuple<T,S,V>
    {
        public Threeuple(T item1, S item2, V item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }
        public T Item1 { get; set; }
        public S Item2 { get; set; }
        public V Item3 { get; set; }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
        }
    }
}
