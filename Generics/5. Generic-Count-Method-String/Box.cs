using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericCountMethodString
{
      public class Box<T> where T: IComparable 
    {

        public Box(List<T> values)
        {
            this.Values = values;
        }
        public List<T> Values { get; set; } = new List<T>();
 
        
        public int CountElements(List<T> list,T element)
        {
            int result = 0;
            foreach (T item in list)
            {
                if (item.CompareTo(element)>0)
                    result++;
            }
            return result;
        }
    }
}
