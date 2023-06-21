using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Dal;
namespace BL
{
  public  class TypeAbilityForProfessionBL
    {
        //שליפת כל הבעלי מקצוע
        public static List<TypeAbilityForProfessionEntities> getAllTypeAbility()
        {
            ScheduleEntities DB = new ScheduleEntities();
            var a = DB.TypeAbilityForProfession.ToList();
            return TypeAbilityForProfessionEntities.ConvertToListTypeAbilityForProfessionEntities(a);

        }
        public static List<TypeAbilityForProfessionEntities> getTypeAbilityForProfessionalByTz(int code)
        {
           
            ScheduleEntities DB = new ScheduleEntities();
           var n= TypeAbilityForProfessionEntities.ConvertToListTypeAbilityForProfessionEntities(DB.TypeAbilityForProfession.Where(j => j.professionalTypeCode == code).ToList());

            DB.SaveChanges();
                return n; 
           
        }

        //הוספת יכולת לבעל מקצוע

        public static bool add(TypeAbilityForProfessionEntities c)

        {
            try { 
            ScheduleEntities DB = new ScheduleEntities();
            DB.TypeAbilityForProfession.Add(TypeAbilityForProfessionEntities.convertToTypeAbilityForProfessionTable(c));
            DB.SaveChanges();
            return true;}
            catch(Exception e)
            {
                return false;
            }

        }

        //עידכון בעל מקצוע ברשימה

        public static List<TypeAbilityForProfessionEntities> update(TypeAbilityForProfessionEntities c)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.TypeAbilityForProfession.FirstOrDefault(c1 => c1.abilityCode == c.abilityCode).abilityName = c.abilityName;
            DB.TypeAbilityForProfession.FirstOrDefault(c1 => c1.abilityCode == c.abilityCode).professionalTypeCode = c.professionalTypeCode;
            
            return getAllTypeAbility();
        }

        //הסרת בעל מקצוע מהרשימה

        public static List<TypeAbilityForProfessionEntities> remove(string c)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.Professional.Remove(DB.Professional.FirstOrDefault(c1 => c1.tz == c));
            DB.SaveChanges();
            return getAllTypeAbility();
        }
    }
}
