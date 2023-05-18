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
        [HttpPost]
        [Route("api/project/{status}")]
        public HttpResponseMessage SpecStat(string stat)
        {
            try
            {
                var data = ProjectService.GetSpec(stat);
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
