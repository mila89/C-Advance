using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementiningCustomStack
{
    public class CustomStack
    {
        private int[] items;
        private const int initialCapacity=4;
        private int count;

        public CustomStack()
        {
            this.items = new int[initialCapacity];
            this.count = 0;
        }

        public int[] Items { get; set; }
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Pop()
        {
            int result = items[0];
            Delete();
            this.count--;
            return result;
        }

        internal void Delete()
        {
            int tempLenght = 0;
            if (Count+initialCapacity < items.Length)
                tempLenght = items.Length + initialCapacity;
            else
                tempLenght = items.Length;
            int[] copyArr = new int[tempLenght];
            for (int i = 1; i < items.Length; i++)
            {
                copyArr[i - 1] = items[i];
            }
            items = copyArr;
        }

        public void Push(int element)
        {
            Insert(element);
            this.count++;
        }

        internal void Insert(int element)
        {
            int tempLenght = 0;
            if (Count == items.Length-1)
                tempLenght = items.Length + initialCapacity;
            else
                tempLenght = items.Length;
            int[] copyArr = new int[tempLenght];
            copyArr[0] = element;
            for (int i = 1; i < items.Length; i++)
            {
                copyArr[i] = items[i-1];
            }
            items = copyArr;
        }

        public int Peek()
        {
            int result = int.MinValue;
            if (Count > 0)
                result = items[0];
            else
                throw new ArgumentOutOfRangeException();

            return result;
        }

        public void ForEach(Action<object> Action)
        {
            for (int i = 0; i < this.count; i++)
            {
                Action(items[i]);
            }
        }
    }
}
