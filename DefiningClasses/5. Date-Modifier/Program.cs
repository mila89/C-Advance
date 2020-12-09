using System;

namespace DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();
            date1 = date1.Replace(" ", "/");
            date2 = date2.Replace(" ", "/");
            DateModifier date = new DateModifier();
            TimeSpan days = date.DifferanceDates(date1, date2);
            Console.WriteLine(Math.Abs(days.Days));
        }
    }
}
