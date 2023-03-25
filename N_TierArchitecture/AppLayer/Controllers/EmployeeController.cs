using BLL.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppLayer.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("api/employees/getall")]
        public HttpResponseMessage AllEmployee()
        {
            try
            {
                var data = EmployeeServices.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
