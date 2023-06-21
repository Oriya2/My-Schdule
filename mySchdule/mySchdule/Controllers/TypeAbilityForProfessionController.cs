using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using BL;
namespace mySchdule.Controllers
{
    [RoutePrefix("api/TypeAbilityForProfession")]

    public class TypeAbilityForProfessionController : ApiController
    {
        [HttpGet]

        [Route("getAllTypeAbilityForProfession")]
        //שליפת כל המשתמשים
        public IHttpActionResult getAllTypeAbilityForProfession()
        {

            var a = TypeAbilityForProfessionBL.getAllTypeAbility();
            return Ok(a);
        }
        [Route("getTypeAbilityForProfessionalByTz/{code}")]
        //שליפת כל המשתמשים
        public IHttpActionResult getTypeAbilityForProfessionalByTz(int code)
        {

            var a = TypeAbilityForProfessionBL.getTypeAbilityForProfessionalByTz(code);
            return Ok(a);
        }

        [HttpPost]
        [Route("addTypeAbilityForProfession")]
        public IHttpActionResult addTypeAbilityForProfession([FromBody] TypeAbilityForProfessionEntities t)
        {
            return Ok(TypeAbilityForProfessionBL.add(t));
        }

        [HttpPost]
        [Route("updateTypeAbilityForProfession")]
        public IHttpActionResult updateTypeAbilityForProfession([FromBody] TypeAbilityForProfessionEntities t)
        {
            return Ok(TypeAbilityForProfessionBL.update(t));
        }

        [HttpPost]
        [Route("deleteTypeAbilityForProfession/{tz}")]
        public IHttpActionResult deleteTypeAbilityForProfession(string code)
        {
            return Ok(TypeAbilityForProfessionBL.remove(code));
        }
    }
}
