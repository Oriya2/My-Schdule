using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;

namespace Entities
{
  public  class eventCalendar
    {
       public string title;
       public  string date;
        public string color= "blue";


        public static List<eventCalendar> convert(List<TasksEntities> lt)
        {
            List<eventCalendar> le = new List<eventCalendar>();
            foreach (var item in lt)
            {
                var myHour= item.startTime.TimeOfDay.Hours.ToString();
                var myMinute = item.startTime.TimeOfDay.Minutes.ToString();
                eventCalendar g = new eventCalendar();
                if(item.startTime.TimeOfDay.Hours<10)
                {
                    myHour = "0"+item.startTime.TimeOfDay.Hours.ToString();
                }

                if (item.startTime.TimeOfDay.Minutes < 10)
                {
                    myMinute = "0"+ item.startTime.TimeOfDay.Minutes.ToString() ;
                }



                g.title = item.nameAbilityCode+"- " + myHour + ':' + myMinute;
                if(item.startTime.Month >= 10 && item.startTime.Day>= 10)
                g.date = item.startTime.Year.ToString() + "-" + item.startTime.Month.ToString() + "-" + item.startTime.Day.ToString();
             else
                      if (item.startTime.Month > 10 && item.startTime.Day < 10)
                    g.date = item.startTime.Year.ToString() + "-" + item.startTime.Month.ToString() + "-0" + item.startTime.Day.ToString();
                else
                          if (item.startTime.Month < 10 && item.startTime.Day >10)
                    g.date = item.startTime.Year.ToString() + "-0" + item.startTime.Month.ToString() + "-" + item.startTime.Day.ToString();
                else
                          if (item.startTime.Month < 10 && item.startTime.Day < 10)
                    g.date = item.startTime.Year.ToString() + "-0" + item.startTime.Month.ToString() + "-0" + item.startTime.Day.ToString();
                


                le.Add(g);
            }
            return le;
        }
    }
}
