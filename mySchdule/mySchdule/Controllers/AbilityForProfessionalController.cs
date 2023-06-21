using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using Entities;

namespace mySchdule.Controllers
{ [RoutePrefix("api/AbilityForProfessional")]
    public class AbilityForProfessionalController : ApiController
    {
        

        
            [HttpGet]

            [Route("getAllAbilityForProfessional")]
            public IHttpActionResult getAllAbilityForProfessional()
            {

                var a = AbilityForProfessionalBL.getAllAbilityForProfessional();
                return Ok(a);
            }

            [HttpGet]
            [Route("getAbilityForProfessionalByTz/{tz}")]
            public IHttpActionResult getAbilityForProfessionalByTz(string tz)
            {
                return Ok(AbilityForProfessionalBL.getAbilityForProfessionalByTz(tz));
            }

            [HttpPut]
            [Route("add")]
            public IHttpActionResult addAbilityForProfessional([FromBody] AbilityForProfessionalEntities a)
            {
                return Ok(AbilityForProfessionalBL.add(a));
            }

            [HttpPost]
            [Route("update")]
            public IHttpActionResult updateAbilityForProfessional([FromBody] AbilityForProfessionalEntities a)
            {
                return Ok(AbilityForProfessionalBL.update(a));
            }

            [HttpPost]
            [Route("delete/{tz}")]
            public IHttpActionResult deleteAbilityForProfessional(int code)
            {
                return Ok(AbilityForProfessionalBL.remove(code));
            }
        }
    }



