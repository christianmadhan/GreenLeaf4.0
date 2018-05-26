using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLeaf4._1.Helpers
{
    public class DateTimeConverter
    {
        public static string DateConverter(string date)
        {
            var parsedDate = DateTime.Parse(date);
            return parsedDate.Date.ToString();
        }
    }
}
