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
    [RoutePrefix("api/customers")]
    [Authorize]
    public class CustomersController : ApiController
    {
        private ICustomerService customerService;

        public CustomersController(ICustomerService customerContext)
        {
            this.customerService = customerContext;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var list = customerService.GetAll();

                if (list == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest);

                return Request.CreateResponse(HttpStatusCode.OK, list.Select(x => new
                {
                    id = x.CustomerId,
                    name = x.Name,
                    cnpj = x.Cpf,
                    phone = x.Phone
                    //birthDate = x.BirthDate
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

                var broker = customerService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, broker);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(CustomerContract contract)
        {
            if (contract == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                customerService.Create(contract);
                return Request.CreateResponse(HttpStatusCode.OK, Messages.CustomerSuccessfulyRegistered);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
