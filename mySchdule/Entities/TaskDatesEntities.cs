using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Entities
{
  public  class TaskDatesEntities
    {
        public int code { get; set; }
        public int taskCode { get; set; }
        public System.DateTime dateToFinish { get; set; }
        public static TaskDatesEntities convertToTaskDatesEntities(TaskDates a)
        {
            TaskDatesEntities a1 = new TaskDatesEntities()
            {
                code = a.code,
                taskCode = a.taskCode,
                dateToFinish = a.dateToFinish
               
            };

            return a1;
        }
        //2-המרת משתנה מנותק למשתנה מסוג מסד נתונים
        public static TaskDates convertToTaskDatesTable(TaskDatesEntities a)
        {
            TaskDates a1 = new TaskDates()
            {
                code = a.code,
                taskCode = a.taskCode,
                dateToFinish = a.dateToFinish
            };
            return a1;
        }
        //3-המרת רשימה מנותקת לרישימה מסוג מסד נתונים
        public static List<TaskDates> ConvertToListTasksDatesTable(List<TaskDatesEntities> lc)
        {
            List<TaskDates> lc1 = new List<TaskDates>();
            foreach (var item in lc)
            {
                lc1.Add(convertToTaskDatesTable(item));
            }
            return lc1;
        }
        //4-המרת רשימה מסוג מסד נתונים לרשימה מנותקת
        public static List<TaskDatesEntities> ConvertToListTasksDatesEntities(List<TaskDates> lc)
        {
            List<TaskDatesEntities> lc1 = new List<TaskDatesEntities>();
            foreach (var item in lc)
            {
                lc1.Add(convertToTaskDatesEntities(item));
            }
            return lc1;
        }
    }
}
