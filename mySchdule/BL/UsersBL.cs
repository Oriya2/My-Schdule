using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Dal;


namespace BL
{
   public class UsersBL
    {
        //שליפת כל המשתמשים
        public static List<UsersEntities> getAllUsers()
        {
            ScheduleEntities DB = new ScheduleEntities();
            
            return UsersEntities.ConvertToListUsersEntities(DB.Users.ToList());

        }
        //בדיקה האם קיים לפי תז 

        public static UsersEntities getUserByTz(string tz)
        {
            ScheduleEntities DB = new ScheduleEntities();
            DB.SaveChanges();
            var a = DB.Users.FirstOrDefault(j => j.tz == tz);
            return UsersEntities.convertToUsersEntities(a);
        }
       
        //הוספת משתמש לרשימת המשתמשים

        public static bool add(UsersEntities c)
        {
            try
            {
                ScheduleEntities DB = new ScheduleEntities();
                DB.Users.Add(UsersEntities.convertToUsersTable(c));
                DB.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
        public static bool resetPassword(UsersEntities c)
        {
            try
            {
                ScheduleEntities DB = new ScheduleEntities();
                DB.Users.FirstOrDefault(c1 => c1.tz == c.tz).password = c.password;
                DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //עידכון משתמש

        public static bool update(UsersEntities u)
        {
            try {
                ScheduleEntities DB = new ScheduleEntities();
                DB.Users.FirstOrDefault(c1 => c1.tz == u.tz).mail = u.mail;
                DB.Users.FirstOrDefault(c1 => c1.tz == u.tz).password = u.password;
                DB.Users.FirstOrDefault(c1 => c1.tz == u.tz).phone = u.phone;
                DB.Users.FirstOrDefault(c1 => c1.tz == u.tz).lastName = u.lastName;
                DB.Users.FirstOrDefault(c1 => c1.tz == u.tz).firstName = u.firstName;
                DB.Users.FirstOrDefault(c1 => c1.tz == u.tz).lat = u.lat;
                DB.Users.FirstOrDefault(c1 => c1.tz == u.tz).lng = u.lng;
                DB.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            }

        //עידכון סיסמא למשתמש
        //public static bool updatePassword(UsersEntities u)
        //{
        //    try
        //    {
        //        ScheduleEntities DB = new ScheduleEntities();
        //        DB.Users.FirstOrDefault(c1 => c1.tz == u.tz).password = u.password;
        //        DB.SaveChanges();
        //        return true;
        //    }
        //    catch(Exception e)
        //    {
        //        return false;
        //    }
        //}


        //הסרת משתמש מהרשימה

        public static bool remove(string c)
        {
            try { 
            ScheduleEntities DB = new ScheduleEntities();
            DB.Users.Remove(DB.Users.FirstOrDefault(c1 => c1.tz == c));
            DB.SaveChanges();
            return true;}
            catch(Exception e)
            {
                return false;
            }
        }

        public static UsersEntities checkIfCustomerExist(string tz, string password)
        {
            ScheduleEntities DB = new ScheduleEntities();
            var a = DB.Users.FirstOrDefault(j => j.tz.Trim() == tz.Trim() && j.password.Trim() == password.Trim());
            if (a == null)
                return null;
            return UsersEntities.convertToUsersEntities(a);
            //return Dal.Converts.UserConvert.convertToUserEntities(a);
            //return UsersEntities.convertToUsersEntities(DB.Users.FirstOrDefault(j => j.tz == tz));

        }

    }
}
