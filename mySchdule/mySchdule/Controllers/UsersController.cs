using BL;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Entities;
namespace mySchdule.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("getAllUsers")]
        //שליפת כל המשתמשים
        public IHttpActionResult getAllUsers()
        {

            var a = UsersBL.getAllUsers();
            return Ok(a);
        }
        //בדיקה האם קיים לפי תז 

        [HttpGet]
        [Route("getUserByTz/{tz}")]
        public IHttpActionResult getUserByTz(string tz)
        {
            return Ok(UsersBL.getUserByTz(tz));
        }

        // בדיקה אם משתמש קיים לפי תעודת זהות וסיסמא

        [HttpGet]
        [Route("checkIfCustomerExist/{tz}/{password}")]
        public IHttpActionResult checkIfCustomerExist(string tz, string password)
        {
            var u = UsersBL.checkIfCustomerExist(tz, password);
            return Ok(u);
        }

        [HttpGet]
        [Route("SendMassage/{adress}/{typeCode}/{password}")]
        public IHttpActionResult SendMassage(string adress, int typeCode, string password)
        {
            //location of this files in running time
            var location= HttpRuntime.AppDomainAppPath;
            var u = MailBL.SendMassage(adress, typeCode,password,location);
            return Ok(u);
        }

        [HttpGet]
        [Route("mailEeserPassword/{adress}/{typeCode}/{newPassword}")]
        public IHttpActionResult mailEeserPassword(string adress, int typeCode, string newPassword)
        {
            //location of this files in running time
            var location = HttpRuntime.AppDomainAppPath;
            var u = MailBL.mailEeserPassword(adress, typeCode, newPassword, location);
            return Ok(u);
        }



        //הוספת משתמש לרשימת המשתמשים
        [HttpPut]
        [Route("add")]
    
        public IHttpActionResult add([FromBody] UsersEntities u)
        {
            return Ok(UsersBL.add(u));
        }

        //עדכון פרטי משתמש
        [HttpPost]
        [Route("update")]
        public IHttpActionResult updateUser([FromBody] UsersEntities u)
        {
            return Ok(UsersBL.update(u));
        }

        ////עידכון סיסמא למשתמש
        //[HttpPost]
        //[Route("updatePassword}")]
        //public IHttpActionResult updatePassword([FromBody] UsersEntities u)
        //{
        //    return Ok(UsersBL.resetPassword(u));
        //}


        [HttpDelete]
        [Route("deleteUser/{tz}")]
        public IHttpActionResult deleteUser(string tz)
        {
            return Ok(UsersBL.remove(tz));
        }
    }
}