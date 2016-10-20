using Insurance.Common.Resources;
using Insurance.Domain.Contracts;
using Insurance.Domain.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Insurance.Api.Controllers
{
    [RoutePrefix("api/brokers")]
    public class BrokersController : ApiController
    {
        private IBrokerService service;

        public BrokersController(IBrokerService context)
        {
            this.service = context;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var list = service.GetAll();

                if (list == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest);

                return Request.CreateResponse(HttpStatusCode.OK, list.Select(x => new
                {
                    id = x.BrokerId,
                    name = x.Name,
                    cnpj = x.Cnpj,
                    city = x.City
                }));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                if (id == 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest);

                var broker = service.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, broker);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public HttpResponseMessage Post(BrokerContract contract)
        {
            if (contract == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                service.Create(contract);
                return Request.CreateResponse(HttpStatusCode.OK, Messages.BrokerSuccessfulyRegistered);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
