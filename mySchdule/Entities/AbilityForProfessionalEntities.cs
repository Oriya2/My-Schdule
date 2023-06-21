using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AbilityForProfessionalEntities
    {
        // משתנים
        public int abilityCodeForProfessional { get; set; }
        public string tzProfessional { get; set; }
        public int abilityCode { get; set; }
        public double taskLength { get; set; }
        public string nameability { get; set; }
        // פונקציות המרה

        //1-המרת משתנה מסוג מסד נתונים למשתה מנותק
        public static AbilityForProfessionalEntities convertToAbilityForProfessionalEntities(AbilityForProfessional a)
        {
            AbilityForProfessionalEntities a1 = new AbilityForProfessionalEntities() {
                abilityCodeForProfessional=a.abilityCodeForProfessional,
                tzProfessional=a.tzProfessional,
                abilityCode=a.abilityCode,
                taskLength=a.taskLength,
                nameability=a.TypeAbilityForProfession?.abilityName
            };

            return a1;
        }
        //2-המרת משתנה מנותק למשתנה מסוג מסד נתונים
        public static AbilityForProfessional convertToAbilityForProfessionalTable(AbilityForProfessionalEntities a)
        {
            AbilityForProfessional a1 = new AbilityForProfessional() {
                abilityCodeForProfessional = a.abilityCodeForProfessional,
                tzProfessional = a.tzProfessional,
                abilityCode = a.abilityCode,
                taskLength = a.taskLength
            };
            return a1;
        }
        //3-המרת רשימה מנותקת לרישימה מסוג מסד נתונים
        public static List<AbilityForProfessional> ConvertToListAbilityForProfessionalTable(List<AbilityForProfessionalEntities> lc)
        {
            List<AbilityForProfessional> lc1 = new List<AbilityForProfessional>();
            foreach (var item in lc)
            {
                lc1.Add(convertToAbilityForProfessionalTable(item));
            }
            return lc1;
        }
        //4-המרת רשימה מסוג מסד נתונים לרשימה מנותקת
        public static List<AbilityForProfessionalEntities> ConvertToListAbilityForProfessionalEntities(List<AbilityForProfessional> lc)
        {
            List<AbilityForProfessionalEntities> lc1 = new List<AbilityForProfessionalEntities>();
            foreach (var item in lc)
            {
                lc1.Add(convertToAbilityForProfessionalEntities(item));
            }
            return lc1;
        }

    }
}
