using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Entities
{
 public   class SchedulingEntities
    {
        public int code { get; set; }
        public int taskCode { get; set; }
        public System.TimeSpan startHour { get; set; }
        public System.TimeSpan endHour { get; set; }
        public System.DateTime date { get; set; }

        public static SchedulingEntities convertToSchedulingEntities(Scheduling a)
        {
            SchedulingEntities a1 = new SchedulingEntities()
            {
                code = a.code,
                taskCode = a.taskCode,
                startHour = a.startHour,
                endHour = a.endHour,
                date = a.date

            };

            return a1;
        }
        //2-המרת משתנה מנותק למשתנה מסוג מסד נתונים
        public static Scheduling convertToSchedulingTable(SchedulingEntities a)
        {
            Scheduling a1 = new Scheduling()
            {
                code = a.code,
                taskCode = a.taskCode,
                startHour = a.startHour,
                endHour = a.endHour,
                date = a.date
            };
            return a1;
        }
        //3-המרת רשימה מנותקת לרישימה מסוג מסד נתונים
        public static List<Scheduling> ConvertToListSchedulingTable(List<SchedulingEntities> lc)
        {
            List<Scheduling> lc1 = new List<Scheduling>();
            foreach (var item in lc)
            {
                lc1.Add(convertToSchedulingTable(item));
            }
            return lc1;
        }
        //4-המרת רשימה מסוג מסד נתונים לרשימה מנותקת
        public static List<SchedulingEntities> ConvertToListSchedulingEntities(List<Scheduling> lc)
        {
            List<SchedulingEntities> lc1 = new List<SchedulingEntities>();
            foreach (var item in lc)
            {
                lc1.Add(convertToSchedulingEntities(item));
            }
            return lc1;
        }
    }
}
