using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Entities
{
  public  class TasksEntities
        
    {
        public int code { get; set; }
        public DateTime DateInsert { get; set; }
        public int RangeDays { get; set; }
        public string tzClient { get; set; }
        public string tzProfessional { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int requireStatus { get; set; }
        public int typeAbilityCode { get; set; }
        public string abilityName { get; set; }

       public string nameAbilityCode { get; set; }

        public string nameClient { get; set; }
        public string nameProfessional { get; set; }
        // פונקציות המרה

        //1-המרת משתנה מסוג מסד נתונים למשתה מנותק
        public static TasksEntities convertToTasksEntities(Tasks a)
        { ScheduleEntities DB = new ScheduleEntities();
            List<AbilityForProfessional> x = a.Users.AbilityForProfessional.ToList();
            string ch = "";
            var e = DB.TypeAbilityForProfession.FirstOrDefault(b => b.abilityCode == a.typeAbilityCode)?.abilityName;
            foreach (var item in x)

            {
                ch = item.TypeAbilityForProfession?.abilityName;

            }
            TasksEntities a1 = new TasksEntities()
            {
                code = a.code,
                DateInsert = a.DateInsert,
                RangeDays = a.RangeDays,
                tzClient = a.tzClient,
                tzProfessional = a.tzProfessional,
                startTime = a.startTime,
                endTime = a.endTime,
                requireStatus = a.requireStatus,
                typeAbilityCode = a.typeAbilityCode,
                nameProfessional = DB.Users.FirstOrDefault(g => g.tz == a.tzProfessional).firstName + " " + DB.Users.FirstOrDefault(g => g.tz == a.tzProfessional).lastName,
                nameClient = a.Users.firstName + " " + a.Users.lastName
                ,
                nameAbilityCode =e
            };

            return a1;
        }
        //2-המרת משתנה מנותק למשתנה מסוג מסד נתונים
        public static Tasks convertToTasksTable(TasksEntities a)
        {
            Tasks a1 = new Tasks()
            {
                code = a.code,
                DateInsert = a.DateInsert,
                RangeDays = a.RangeDays,
                tzClient = a.tzClient,
                tzProfessional = a.tzProfessional,
                startTime = a.startTime,
                endTime = a.endTime,
                requireStatus = a.requireStatus,
                typeAbilityCode = a.typeAbilityCode

            };
            return a1;
        }
        //3-המרת רשימה מנותקת לרישימה מסוג מסד נתונים
        public static List<Tasks> ConvertToListTasksTable(List<TasksEntities> lc)
        {
            List<Tasks> lc1 = new List<Tasks>();
            foreach (var item in lc)
            {
                lc1.Add(convertToTasksTable(item));
            }
            return lc1;
        }
        //4-המרת רשימה מסוג מסד נתונים לרשימה מנותקת
        public static List<TasksEntities> ConvertToListTasksEntities(List<Tasks> lc)
        {
            List<TasksEntities> lc1 = new List<TasksEntities>();
            foreach (var item in lc)
            {
                lc1.Add(convertToTasksEntities(item));
            }
            return lc1;
        }
    }
}
