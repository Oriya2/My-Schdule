using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Dal;
namespace BL
{
   public class TypeProfessionBL
    {
        //שליפת כל סוגי המקצועות
        public static List<TypeProfessionEntities> getAllTypeProfession()
        {
            ScheduleEntities DB = new ScheduleEntities();
            var a = DB.TypeProfession.ToList();
            return TypeProfessionEntities.ConvertToListTypeProfessionEntities(a);

        }


        //הוספת בעל מקצוע לרשימת המשתמשים

        public static bool add(TypeProfessionEntities c)

        {
            try { 
            ScheduleEntities DB = new ScheduleEntities();
            DB.TypeProfession.Add(TypeProfessionEntities.convertToTypeProfessionTable(c));
            DB.SaveChanges();
            return true;}
            catch(Exception e )
            { return false; }

        }

        //עידכון בעל מקצוע ברשימה

        public static List<TypeProfessionEntities> update(TypeProfessionEntities c)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.TypeProfession.FirstOrDefault(c1 => c1.professionalTypeCode == c.professionalTypeCode).professionalName = c.professionalName;

            DB.SaveChanges();
            return getAllTypeProfession();
        }

        //הסרת בעל מקצוע מהרשימה

        public static List<TypeProfessionEntities> remove(int c)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.TypeProfession.Remove(DB.TypeProfession.FirstOrDefault(c1 => c1.professionalTypeCode == c));
            DB.SaveChanges();
            return getAllTypeProfession();
        }
    }
}
