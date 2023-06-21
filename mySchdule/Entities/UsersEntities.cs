using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Entities
{
   public class UsersEntities
    {
        public string tz { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
        public Nullable<double> lat { get; set; }
        public Nullable<double> lng { get; set; } // פונקציות המרה

        //1-המרת משתנה מסוג מסד נתונים למשתה מנותק
        public static UsersEntities convertToUsersEntities(Users a)
        {
            UsersEntities a1 = new UsersEntities()
            {
                tz = a.tz,
                firstName = a.firstName,
                lastName = a.lastName,
                password = a.password,
                mail = a.mail,
                phone = a.phone,
                lat=a.lat,
                lng=a.lng
            };

            return a1;
        }
        //2-המרת משתנה מנותק למשתנה מסוג מסד נתונים
        public static Users convertToUsersTable(UsersEntities a)
        {
            Users a1 = new Users()
            {
                tz = a.tz,
                firstName = a.firstName,
                lastName = a.lastName,
                password = a.password,
                mail = a.mail,
                phone = a.phone,
                lat = a.lat,
                lng = a.lng
            };
            return a1;
        }
        //3-המרת רשימה מנותקת לרישימה מסוג מסד נתונים
        public static List<Users> ConvertToListUsersTable(List<UsersEntities> lc)
        {
            List<Users> lc1 = new List<Users>();
            foreach (var item in lc)
            {
                lc1.Add(convertToUsersTable(item));
            }
            return lc1;
        }
        //4-המרת רשימה מסוג מסד נתונים לרשימה מנותקת
        public static List<UsersEntities> ConvertToListUsersEntities(List<Users> lc)
        {
            List<UsersEntities> lc1 = new List<UsersEntities>();
            foreach (var item in lc)
            {
                lc1.Add(convertToUsersEntities(item));
            }
            return lc1;
        }
    }
}
