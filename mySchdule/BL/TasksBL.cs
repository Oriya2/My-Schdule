using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Dal;
namespace BL
{
    public class TasksBL
    {
        //שליפת כל המשימות
        public static List<TasksEntities> getAllTasks()
        {
            ScheduleEntities DB = new ScheduleEntities();
            return TasksEntities.ConvertToListTasksEntities(DB.Tasks.ToList());
        }


        //הוספת משימה
        public static bool add(TasksEntities t)
        {
            try
            {
                ScheduleEntities DB = new ScheduleEntities();
                if (t.tzProfessional == t.tzClient)
                    return false;
                if (t.startTime <DateTime.Today)
                    return false;
                var a = DB.Tasks.FirstOrDefault(n => n.startTime == t.startTime);
                if (a == null)
                {
                    DB.Tasks.Add(TasksEntities.convertToTasksTable(t));
                    DB.SaveChanges();
                    return true;
                }
                DB.Tasks.Add(TasksEntities.convertToTasksTable(t));
                DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        //שליפת משימה לפי תז בעל מקצוע
        public static List<TasksEntities> getTasksByTz(string code)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.SaveChanges();

            return TasksEntities.ConvertToListTasksEntities(DB.Tasks.Where(j => j.tzProfessional == code).ToList());
        }
        //שליפת משימה לפי סטטוס הזמנה
        public static List<TasksEntities> getTasksByStatus(int val)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.SaveChanges();
            return TasksEntities.ConvertToListTasksEntities(DB.Tasks.Where(j => j.requireStatus == val).ToList());



        }   //שליפת משימה לפי סטטוס הזמנה
        public static TasksEntities getTasksByCode(int val)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.SaveChanges();
            return TasksEntities.convertToTasksEntities(DB.Tasks.FirstOrDefault(j => j.code == val));



        }
        //שליפת משימה לפי תאריך
        //public static List<TasksEntities> getTasksByDate(DateTime date)
        //{
        //    ScheduleEntities DB = new ScheduleEntities();
        //    DB.SaveChanges();

        //    return TasksEntities.ConvertToListTasksEntities(DB.Tasks.Where(j => j. == date).ToList());
        //}
        //שליפת משימה לפי לקוח
        public static List<TasksEntities> getTasksByCustumers(Users c)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.SaveChanges();

            return TasksEntities.ConvertToListTasksEntities(DB.Tasks.Where(j => j.tzClient == c.tz).ToList());
        }
        ////הוספת משימה לבעל מקצוע
        //public static List<TasksEntities> add(TasksEntities c)

        //{
        //    ScheduleEntities DB = new ScheduleEntities();
        //    DB.Tasks.Add(TasksEntities.convertToTasksTable(c));
        //    DB.SaveChanges();
        //    return getTasksByTz(c.tzProfessional);

        //}
        //עידכון משימה ברשימה
        public static TasksEntities update(TasksEntities c)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.Tasks.FirstOrDefault(c1 => c1.code == c.code).DateInsert = c.DateInsert;
            DB.Tasks.FirstOrDefault(c1 => c1.code == c.code).RangeDays = c.RangeDays;
            DB.Tasks.FirstOrDefault(c1 => c1.code == c.code).tzClient = c.tzClient;
            DB.Tasks.FirstOrDefault(c1 => c1.code == c.code).tzProfessional = c.tzProfessional;
            DB.Tasks.FirstOrDefault(c1 => c1.code == c.code).startTime = c.startTime;
            DB.Tasks.FirstOrDefault(c1 => c1.code == c.code).endTime = c.endTime;
            DB.Tasks.FirstOrDefault(c1 => c1.code == c.code).requireStatus = c.requireStatus;
            DB.Tasks.FirstOrDefault(c1 => c1.code == c.code).typeAbilityCode = c.typeAbilityCode;
            DB.SaveChanges();
            return getTasksByCode(c.code);
        }
        public static bool remove(int c)
        {
            try { 
            ScheduleEntities DB = new ScheduleEntities();
            DB.Tasks.Remove(DB.Tasks.FirstOrDefault(c1 => c1.code == c));
            DB.SaveChanges();
            return true;}
            catch(Exception e)
            {
                return false;
            }
        }
    }
}

