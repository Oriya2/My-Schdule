using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Dal;
namespace BL
{
 public   class TaskDatesBL
    {
        //שליפת כל הבעלי מקצוע
        public static List<TaskDatesEntities> getAllTaskDates()
        {
            ScheduleEntities DB = new ScheduleEntities();
            var a = DB.TaskDates.ToList();
            return TaskDatesEntities.ConvertToListTasksDatesEntities(a);

        }
        

        //הוספת בעל מקצוע לרשימת המשתמשים

        public static List<TaskDatesEntities> add(TaskDatesEntities c)

        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.TaskDates.Add(TaskDatesEntities.convertToTaskDatesTable(c));
            DB.SaveChanges();
            return getAllTaskDates();

        }

        //עידכון בעל מקצוע ברשימה

        public static List<TaskDatesEntities> update(TaskDatesEntities c)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.TaskDates.FirstOrDefault(c1 => c1.code == c.code).taskCode = c.taskCode;
            DB.TaskDates.FirstOrDefault(c1 => c1.code == c.code).dateToFinish = c.dateToFinish;
      
            DB.SaveChanges();
            return getAllTaskDates();
        }

        //הסרת בעל מקצוע מהרשימה

        public static List<TaskDatesEntities> remove(int c)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.TaskDates.Remove(DB.TaskDates.FirstOrDefault(c1 => c1.code == c));
            DB.SaveChanges();
            return getAllTaskDates();
        }
    }
}
