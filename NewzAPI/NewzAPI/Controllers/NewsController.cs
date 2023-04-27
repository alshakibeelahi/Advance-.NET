using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewzAPI.Controllers
{
    public class NewsController : ApiController
    {
        [HttpGet]
        [Route("api/news")]
        public HttpResponseMessage AllNews()
        {
            try
            {
                var data = NewzServices.AllNews();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/news/{id}")]
        public HttpResponseMessage SpecNews(int id)
        {
            try
            {
                var data = NewzServices.SpecNews(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpPost]
        [Route("api/news/add")]
        public HttpResponseMessage Add(NewzDTOs nwz)
        {
            try
            {
                var data = NewzServices.Insert(nwz);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        /*
        [HttpGet]
        [Route("api/news/cat")]
        public HttpResponseMessage CatNews(string name)
        {
            try
            {
                var data = NewzServices.CatNewz(name);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }*/

    }
}
