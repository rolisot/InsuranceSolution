using Insurance.Common.Resources;
using Insurance.Domain.Contracts;
using Insurance.Domain.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Insurance.Api.Controllers
{
    [RoutePrefix("api/signature")]
    public class SignatureController : ApiController
    {
        private IPlanService service;

        public SignatureController(IPlanService context)
        {
            this.service = context;
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public HttpResponseMessage PostSignature(SignatureContract contract)
        {
            if (contract == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                service.Signature(contract);
                return Request.CreateResponse(HttpStatusCode.OK, Messages.PlanSuccessfulyRegistered);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
