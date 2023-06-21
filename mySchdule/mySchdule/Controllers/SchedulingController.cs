using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
namespace mySchdule.Controllers
{
    [RoutePrefix("api/Scheduling")]
    public class SchedulingController : ApiController
    {[HttpGet]
        [Route("getbyid/{tz}")]
        public IHttpActionResult getById(string tz)
        {
            return Ok(SchedulingBL.getEventById(tz));
        }

        [HttpGet]
        [Route("getEventByIdCust/{tz}")]
        public IHttpActionResult getEventByIdCust(string tz)
        {
            return Ok(SchedulingBL.getEventByIdCust(tz));
        }



        
    }
}
