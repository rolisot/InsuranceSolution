using Insurance.Api.Contracts;
using Insurance.Common.Resources;
using Insurance.Domain.Services;
using System;
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
        private IUserService _service;

        public UsersController(IUserService service)
        {
            this._service = service;
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage PostUser(CreateUserContract contract)
        {
            if (contract == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                _service.Create(contract.Email, contract.Password, contract.ConfirmPassword);
                return Request.CreateResponse(HttpStatusCode.OK, Messages.UserSuccessfulyRegistered);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
