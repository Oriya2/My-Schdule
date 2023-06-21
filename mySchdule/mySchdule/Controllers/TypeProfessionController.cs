using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using Entities;
using Dal;

namespace mySchdule.Controllers
{

    [RoutePrefix("api/TypeProfession")]

    public class TypeProfessionController : ApiController
    {
        [HttpGet]

        [Route("getAllTypeProfession")]
        //שליפת כל המשתמשים
        public IHttpActionResult getAllTypeProfession()
        {

            var a = TypeProfessionBL.getAllTypeProfession();
            return Ok(a);
        }

        [HttpPost]
        [Route("addTypeProfession")]
        public IHttpActionResult addTypeProfession([FromBody] TypeProfessionEntities t)
        {
            return Ok(TypeProfessionBL.add(t));
        }

        [HttpPost]
        [Route("updateTypeProfession")]
        public IHttpActionResult updateTypeProfession([FromBody] TypeProfessionEntities t)
        {
            return Ok(TypeProfessionBL.update(t));
        }

        [HttpPost]
        [Route("deleteTypeProfession/{tz}")]
        public IHttpActionResult deleteTypeProfession(int code)
        {
            return Ok(TypeProfessionBL.remove(code));
        }
    }
}
