using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Entities
{
    public class TypeProfessionEntities
    {
        public int professionalTypeCode { get; set; }
        public string professionalName { get; set; }

        // פונקציות המרה

        //1-המרת משתנה מסוג מסד נתונים למשתה מנותק
        public static TypeProfessionEntities convertToTypeProfessionEntities(TypeProfession a)
        {
            TypeProfessionEntities a1 = new TypeProfessionEntities()
            {
                professionalTypeCode = a.professionalTypeCode,
                professionalName = a.professionalName
            };

            return a1;
        }
        //2-המרת משתנה מנותק למשתנה מסוג מסד נתונים
        public static TypeProfession convertToTypeProfessionTable(TypeProfessionEntities a)
        {
            TypeProfession a1 = new TypeProfession()
            {
                professionalTypeCode = a.professionalTypeCode,
                professionalName = a.professionalName
            };
            return a1;
        }
        //3-המרת רשימה מנותקת לרישימה מסוג מסד נתונים
        public static List<TypeProfession> ConvertToListTypeProfessionTable(List<TypeProfessionEntities> lc)
        {
            List<TypeProfession> lc1 = new List<TypeProfession>();
            foreach (var item in lc)
            {
                lc1.Add(convertToTypeProfessionTable(item));
            }
            return lc1;
        }
        //4-המרת רשימה מסוג מסד נתונים לרשימה מנותקת
        public static List<TypeProfessionEntities> ConvertToListTypeProfessionEntities(List<TypeProfession> lc)
        {
            List<TypeProfessionEntities> lc1 = new List<TypeProfessionEntities>();
            foreach (var item in lc)
            {
                lc1.Add(convertToTypeProfessionEntities(item));
            }
            return lc1;
        }
    }
}
