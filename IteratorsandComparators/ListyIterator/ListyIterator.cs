using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> items;
        public ListyIterator()
        {
            items = new List<T>();
        }
        public ListyIterator(List<T> list)
        {
            this.items = new List<T>(list);
            Index = 0;
        }

        public T CurrentItem { get; set; }
        public int Index { get; set; }
        public int Count 
        { get=>items.Count;  }
        public bool Move()
        {
            if (HasNext())
            {
                this.Index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (this.Index+1 >= this.items.Count)
                return false;
            return true;
        }

        public void Print()
        {
            try
            {
                Console.WriteLine(items[this.Index]);
            }
            catch 
            {
                Console.WriteLine("Invalid Operation!");
            }
        }
    }
}
