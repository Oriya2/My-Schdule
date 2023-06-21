using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Dal;

namespace BL
{
  public  class ProfessionalBL
    {
        //שליפת כל הבעלי מקצוע
        public static List<ProfessionalEntities> getAllProfessional()
        {
            ScheduleEntities DB = new ScheduleEntities();
            List<Professional> a = new List<Professional>();

             a = DB.Professional.ToList();
            //List<Users> s = new List<Users>();
            //foreach (var item in a)
            //{
            //     s.Add ( DB.Users.FirstOrDefault(y => y.tz == item.tz));
            //}
            return ProfessionalEntities.ConvertToListProfessionalEntities(a);

        }

        //שליפת בעל מקצוע לפי תז 

        public static  ProfessionalEntities getAbilityForProfessionalByTz(string tz)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.SaveChanges();

         var a= ProfessionalEntities.convertToProfessionalEntities(DB.Professional.FirstOrDefault(j => j.tz == tz));
           
            return a;
        }
        public static ProfessionalEntities getAbilityForProfessionalByName(string tz,string name)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.SaveChanges();

            var a = ProfessionalEntities.convertToProfessionalEntities(DB.Professional.FirstOrDefault(j => j.tz == tz));
            a.nameProf[0] = a.nameProf.FirstOrDefault(j => j == name);
           var b = DB.TypeAbilityForProfession.Where(j => j.abilityName == a.nameProf[0]).ToList();
            a.jobs = null;
            foreach (var item in b)
            {
                a.jobs.Add(item.abilityName);
            }
            return a;
        }

        //הוספת בעל מקצוע לרשימת בעלי המקצוע

        public static bool add(ProfessionalEntities c,int code)

        {
          try  { 
            ScheduleEntities DB = new ScheduleEntities();
            DB.Professional.Add(ProfessionalEntities.convertToProfessionalTable(c));
            DB.SaveChanges();
                AbilityForProfessional a=new AbilityForProfessional();
                a.abilityCode = code;
                a.taskLength = 5;
                a.tzProfessional = c.tz;
                DB.AbilityForProfessional.Add(a);
            DB.SaveChanges();
            return true;
        }
            catch(Exception e)
            {
                return false;
            }
          
        }
        public static ProfessionalEntities ifExistProfessionalByTz(string code)
        {
          
         ScheduleEntities DB = new ScheduleEntities();
         ProfessionalEntities s= ProfessionalEntities.convertToProfessionalEntities(DB.Professional.FirstOrDefault(j => j.tz == code));
            return s ;

          
        
           }
        //עידכון בעל מקצוע ברשימה

        public static bool update(ProfessionalEntities c, int code)
        {
            try { 
            ScheduleEntities DB = new ScheduleEntities();
            DB.Professional.FirstOrDefault(c1 => c1.code == c.code).about = c.about;
                DB.Professional.FirstOrDefault(c1 => c1.code == c.code).tz = c.tz;

                DB.Professional.FirstOrDefault(c1 => c1.tz == c.tz).pic = c.pic;
                DB.AbilityForProfessional.FirstOrDefault(c1 => c1.tzProfessional == c.tz).abilityCode = code;
                DB.SaveChanges();
            return true;}
            catch(Exception e)
            {
                return false;
            }
        }
    

        //הסרת בעל מקצוע מהרשימה

        public static bool remove(int c)
        {
            ScheduleEntities DB = new ScheduleEntities();
            try
            {
                DB.Professional.Remove(DB.Professional.FirstOrDefault(c1 => c1.code == c));
                DB.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
