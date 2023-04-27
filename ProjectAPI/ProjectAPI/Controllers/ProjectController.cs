using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectAPI.Controllers
{
    public class ProjectController : ApiController
    {
        [HttpGet]
        [Route("api/project/spec/{status}")]
        public HttpResponseMessage SpecStat(string status)
        {
            try
            {
                var data = ProjectService.GetSpec(status);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/project/all")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = ProjectService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex);
            }
        }
    }
}
