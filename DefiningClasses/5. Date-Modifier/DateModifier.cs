using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public TimeSpan DifferanceDates(string date1, string date2)
        {
            DateTime dt1 = Convert.ToDateTime(date1);
            DateTime dt2 = Convert.ToDateTime(date2);
            TimeSpan days = dt2 - dt1;
          //  Console.WriteLine(dt2-dt1);
            return days; // int.Parse((dt2-dt1).ToString);
        }
    }
}
