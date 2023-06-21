using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Entities;
namespace BL
{
    public class AbilityForProfessionalBL
    {
        //שליפת כל הקטגוריות
        public static List<AbilityForProfessionalEntities> getAllAbilityForProfessional()
        {
            ScheduleEntities DB = new ScheduleEntities();
            var a = DB.AbilityForProfessional.ToList();
            return AbilityForProfessionalEntities.ConvertToListAbilityForProfessionalEntities(a);

        }
        //שליפת קטגוריה לפי תז בעל מקצוע

        public static List<AbilityForProfessionalEntities> getAbilityForProfessionalByTz(string code)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.SaveChanges();

            return AbilityForProfessionalEntities.ConvertToListAbilityForProfessionalEntities(DB.AbilityForProfessional.Where(j => j. tzProfessional== code).ToList());
        }
        //שליפת קטגוריה לפי  קוד יכולת

        public static List<AbilityForProfessionalEntities> getAbilityForProfessionalByCodeAbility(int code)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.SaveChanges();

            return AbilityForProfessionalEntities.ConvertToListAbilityForProfessionalEntities(DB.AbilityForProfessional.Where(j => j.abilityCode == code).ToList());
        }
        //הוספת קטגוריה לרשימת הקטגוריות

        public static bool add(AbilityForProfessionalEntities c)

        {try { 
            ScheduleEntities DB = new ScheduleEntities();
            DB.AbilityForProfessional.Add(AbilityForProfessionalEntities.convertToAbilityForProfessionalTable(c));
            DB.SaveChanges();
            return true;}
            catch(Exception e)
            {
                return false;
            }

        }

        //עידכון קטגוריה ברשימה

        public static List<AbilityForProfessionalEntities> update(AbilityForProfessionalEntities c)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.AbilityForProfessional.FirstOrDefault(c1 => c1.abilityCodeForProfessional == c.abilityCodeForProfessional).abilityCode = c.abilityCode;
            DB.AbilityForProfessional.FirstOrDefault(c1 => c1.abilityCodeForProfessional == c.abilityCodeForProfessional).taskLength = c.taskLength;
            DB.AbilityForProfessional.FirstOrDefault(c1 => c1.abilityCodeForProfessional == c.abilityCodeForProfessional).tzProfessional = c.tzProfessional;
            DB.SaveChanges();
            return getAllAbilityForProfessional();
        }

        //הסרת קטגוריה מהרשימה

        public static List<AbilityForProfessionalEntities> remove(int c)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.AbilityForProfessional.Remove(DB.AbilityForProfessional.FirstOrDefault(c1 => c1.abilityCodeForProfessional == c));
            DB.SaveChanges();
            return getAllAbilityForProfessional();
        }
    }
}

