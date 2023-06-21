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
    [RoutePrefix("api/Tasks")]

    public class TasksController : ApiController
    {

        //שליפת כל המשימות

        [HttpGet]
        [Route("getAlltasks")]
        public IHttpActionResult getAlltasks()
        {
            var a = TasksBL.getAllTasks();
            return Ok(a);
        }
        [HttpGet]
        [Route("getTasksByCode/{code}")]
        public IHttpActionResult getTasksByCode(int code)
        {
            var a = TasksBL.getTasksByCode(code);
            return Ok(a);
        }        //הוספת משימה לרשימת המשימות
        [HttpPut]
        [Route("addTasks")]
        public IHttpActionResult add([FromBody] TasksEntities t)
        {
            var x = TasksBL.add(t);
            return Ok(x);
        }
        [HttpPost]
        [Route("update")]
        public IHttpActionResult update([FromBody] TasksEntities t)
        {
            return Ok(TasksBL.update(t));
        }
        [HttpDelete]
        [Route("delete/{code}")]
        public IHttpActionResult deleteUser(int code)
        {
            return Ok(TasksBL.remove(code));
        }
    }
}
