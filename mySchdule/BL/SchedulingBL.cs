using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Dal;

namespace BL
{
   public class SchedulingBL
    {
        //ע"י קוד  בעל מקצוע
        public static List<eventCalendar> getEventById(string id)
        {
            ScheduleEntities DB = new ScheduleEntities();
            var a= eventCalendar.convert(TasksEntities.ConvertToListTasksEntities(DB.Tasks.Where(s => s.tzProfessional == id&&s.requireStatus==2).ToList()));

            return a;
        }

        //ע"י קוד לקוח
        public static List<eventCalendar> getEventByIdCust(string id)
        {
            ScheduleEntities DB = new ScheduleEntities();
            
             var x=eventCalendar.convert(TasksEntities.ConvertToListTasksEntities(DB.Tasks.Where(s => s.tzClient == id).ToList()));
            foreach (var item in x)
            {
                item.color = "green";
            }

            return x;
        }
    }
}
