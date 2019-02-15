using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TodoApp.Controllers
{
    public class HealthcheckController : ApiController
    {
        // GET api/healthcheck
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DateTime.Now);
        }
    }
}
