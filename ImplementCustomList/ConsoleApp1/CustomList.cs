using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingCustomList
{
    public class CustomList
    {
        private int[] items;
        private const int InitialCapacity = 2;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }


        public int this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[index] = value;
            }
        }

        private void Resize()
        {
            int[] copyArr = new int[items.Length * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                copyArr[i] = this.items[i];
            }
            this.items = copyArr;
        }
        public void Add(int element)
        {
            if (this.items.Length == this.Count)
                Resize();
            items[this.Count] = element;
            this.Count++;
        }

        public int RemoveAt(int index)
        {
            if (index >= items.Length)
                throw new ArgumentOutOfRangeException();

            int result = this.items[index];
            items[index] = default(int);
            Shift(index);
            this.Count--;
            if (Count <= items.Length / 4)
                Shrink();
            return result;
        }

        internal void Shift(int index)
        {
           // int[] copyArr = new int[this.items.Length - 1];
            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        internal void Shrink()
        {
            int[] copyArr = new int[items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                copyArr[i] = items[i];
            }
            items = copyArr;
        }

        internal void ShiftRight(int index)
        {
            for (int i = Count; i >index ; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
        public void Insert(int index, int item)
        {
            if (index < 0 || index >= items.Length)
                throw new ArgumentOutOfRangeException();

            if (Count == items.Length)
                Resize();
            ShiftRight(index);
            items[index] = item;
            Count++;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == element)
                    return true;
            }
            return false;
        }

        public void Swap(int indexFirst, int indexSecond)
        {
            if (indexFirst < 0 || indexFirst >= Count || indexSecond < 0 || indexSecond >= Count)
                throw new ArgumentOutOfRangeException();
            int temp = this.items[indexFirst];
            this.items[indexFirst] = this.items[indexSecond];
            this.items[indexSecond] = temp;
        }
    }
}

