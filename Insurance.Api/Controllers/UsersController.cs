using Insurance.Api.Contracts;
using Insurance.Common.Resources;
using Insurance.Domain.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Insurance.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/account")]
    public class UsersController : ApiController
    {
        private IUserService service;

        public UsersController(IUserService context)
        {
            this.service = context;
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var list = service.GetAll();

                if (list == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest);

                return Request.CreateResponse(HttpStatusCode.OK, list.Select(x => new
                {
                    id = x.UserId,
                    email = x.Email,
                    lastAcess = x.LastAccessDate
                }));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetById(string id)
        {
            try
            {
                if (id == null)
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
        public HttpResponseMessage PostUser(CreateUserContract contract)
        {
            if (contract == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                service.Create(contract.Email, contract.Password, contract.ConfirmPassword);
                return Request.CreateResponse(HttpStatusCode.OK, Messages.UserSuccessfulyRegistered);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
