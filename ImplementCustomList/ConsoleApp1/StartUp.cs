using System;

namespace ImplementingCustomList
{
    class StartUp
    {
        public static void Main()
        {
            CustomList myList = new CustomList();
            
            for (int i = 0; i < 6; i++)
            {
                myList.Add(i + 10);
            }
            myList.Insert(2, 200);
            
            Console.WriteLine(myList.Count);
            Console.WriteLine(myList.RemoveAt(2));
            Console.WriteLine(myList.Contains(11));
            myList.Swap(0, 4);

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }
        }
    }
}
