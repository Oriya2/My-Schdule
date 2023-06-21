using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Entities
{
   public class ProfessionalEntities
    {
        public int code { get; set; }

        public string tz { get; set; }
        public string name { get; set; }
        public List<string> nameProf { get; set; }
        public string mail { get; set; }
        public string pic { get; set; }
        public string about { get; set; }
        public string phone { get; set; }
        public List< string> jobs { get; set; }

        // פונקציות המרה

        //1-המרת משתנה מסוג מסד נתונים למשתה מנותק
        public static ProfessionalEntities convertToProfessionalEntities(Professional a)
        {
            if (a != null)
            {
                List<string> arr = new List<string>();
                List<AbilityForProfessional> h = a.Users.AbilityForProfessional.ToList();
                List < string > x = new List<string>();
                if (h.Count() > 0)
                {
                    foreach (var item in h)

                    {
                        x.Add(item.TypeAbilityForProfession.TypeProfession.professionalName);
                        string ch = item.TypeAbilityForProfession.abilityName;
                        if (arr.IndexOf(ch) < 0)
                            arr.Add(ch);
                    }
                }
                 x=x.Distinct().ToList();
                ProfessionalEntities a1 = new ProfessionalEntities()
                {
                    code = a.code,
                    tz = a.tz,
                    pic = a.pic,
                    about = a.about,
                    name = a.Users.firstName + "  " + a.Users.lastName,
                    mail = a.Users.mail,
                    phone = a.Users.phone,
                    jobs = arr,
                    nameProf =x
                };

                return a1;
            }
            return null;
        }

 

        //2-המרת משתנה מנותק למשתנה מסוג מסד נתונים
        public static Professional convertToProfessionalTable(ProfessionalEntities a)
        {
            Professional a1 = new Professional()
            {
                code = a.code,
                tz = a.tz,
                pic = a.pic,
                about = a.about
            };
            return a1;
        }
        //3-המרת רשימה מנותקת לרישימה מסוג מסד נתונים
        public static List<Professional> ConvertToListProfessionalTable(List<ProfessionalEntities> lc)
        {
            List<Professional> lc1 = new List<Professional>();
            foreach (var item in lc)
            {
                lc1.Add(convertToProfessionalTable(item));
            }
            return lc1;
        }
        //4-המרת רשימה מסוג מסד נתונים לרשימה מנותקת
        public static List<ProfessionalEntities> ConvertToListProfessionalEntities(List<Professional> lc)
        {
            List<ProfessionalEntities> lc1 = new List<ProfessionalEntities>();
            foreach (var item in lc)
            {
                lc1.Add(convertToProfessionalEntities(item));
            }
            return lc1;
        }
    }
}
