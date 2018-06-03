using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLeaf4._1.Helpers
{
    public class DateTimeConverter
    {
        public static DateTime DateConverter(int year, int month, int day,int hour,int minute,int milisecond)
        {
           return new DateTime(year, month, day,hour,minute,milisecond);
        }
    }
}
