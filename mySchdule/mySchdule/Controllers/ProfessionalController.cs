using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using Entities;

namespace mySchdule.Controllers
{[RoutePrefix("api/Professional")]
    public class ProfessionalController : ApiController
    {
        [HttpGet]
        [Route("getAllProfessional")]
        //שליפת כל בעלי המקצוע
        public IHttpActionResult getAllProfessional()
        {

            var a = ProfessionalBL.getAllProfessional();
            return Ok(a);
        }

        //שליפה  לפי תז 

        [HttpGet]
        [Route("getProfessionalByTz/{tz}")]
        public IHttpActionResult getProfessionalByTz(string tz)
        {
            return Ok(ProfessionalBL.getAbilityForProfessionalByTz(tz));
        }
        [HttpGet]
        [Route("ifExistProfessionalByTz/{tz}")]
        public IHttpActionResult ifExistProfessionalByTz(string tz)
        {
            return Ok(ProfessionalBL.ifExistProfessionalByTz(tz));
        }
        [HttpGet]
        [Route("getAbilityForProfessionalByName/{tz}/{name}")]
        public IHttpActionResult getAbilityForProfessionalByName(string tz,string name)
        {
            return Ok(ProfessionalBL.getAbilityForProfessionalByName(tz,name));
        }

        [HttpPost]
        [Route("updateProfessional/{code}")]
        public IHttpActionResult updateProfessional([FromBody] ProfessionalEntities p, int code)
        {
            return Ok(ProfessionalBL.update(p,code));
        }
        [HttpDelete]
        [Route("deleteProf/{id}")]
        public IHttpActionResult deleteProf(int id)
        {
            return Ok(ProfessionalBL.remove(id));
        }
        [HttpPut]
        [Route("add/{code}")]

        public IHttpActionResult add([FromBody] ProfessionalEntities p,int code)
        {

            return Ok(ProfessionalBL.add(p, code));
        }
    }
}
