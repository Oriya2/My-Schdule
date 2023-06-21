using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Entities
{
   public class TypeAbilityForProfessionEntities
    {
        public int abilityCode { get; set; }
        public string abilityName { get; set; }
        public int professionalTypeCode { get; set; }
        // פונקציות המרה

        //1-המרת משתנה מסוג מסד נתונים למשתה מנותק
        public static TypeAbilityForProfessionEntities convertToTypeAbilityForProfessionEntities(TypeAbilityForProfession a)
        {
            TypeAbilityForProfessionEntities a1 = new TypeAbilityForProfessionEntities()
            {
                abilityCode = a.abilityCode,
                abilityName = a.abilityName,
                professionalTypeCode = a.professionalTypeCode
            };

            return a1;
        }
        //2-המרת משתנה מנותק למשתנה מסוג מסד נתונים
        public static TypeAbilityForProfession convertToTypeAbilityForProfessionTable(TypeAbilityForProfessionEntities a)
        {
            TypeAbilityForProfession a1 = new TypeAbilityForProfession()
            {
                abilityCode = a.abilityCode,
                abilityName = a.abilityName,
                professionalTypeCode = a.professionalTypeCode
            };
            return a1;
        }
        //3-המרת רשימה מנותקת לרישימה מסוג מסד נתונים
        public static List<TypeAbilityForProfession> ConvertToListTypeAbilityForProfessionTable(List<TypeAbilityForProfessionEntities> lc)
        {
            List<TypeAbilityForProfession> lc1 = new List<TypeAbilityForProfession>();
            foreach (var item in lc)
            {
                lc1.Add(convertToTypeAbilityForProfessionTable(item));
            }
            return lc1;
        }
        //4-המרת רשימה מסוג מסד נתונים לרשימה מנותקת
        public static List<TypeAbilityForProfessionEntities> ConvertToListTypeAbilityForProfessionEntities(List<TypeAbilityForProfession> lc)
        {
            List<TypeAbilityForProfessionEntities> lc1 = new List<TypeAbilityForProfessionEntities>();
            foreach (var item in lc)
            {
                lc1.Add(convertToTypeAbilityForProfessionEntities(item));
            }
            return lc1;
        }
    }
}
