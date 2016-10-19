using Insurance.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Insurance.Api.Controllers
{
    [RoutePrefix("api/insuranceCompanies")]
    public class InsuranceCompanyController : ApiController
    {
        private IInsuranceCompanyService _service;

        public InsuranceCompanyController(IInsuranceCompanyService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetInsuranceCompanies()
        {
            try
            {
                var list = _service.GetAll();

                if (list == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest);

                return Request.CreateResponse(HttpStatusCode.OK, list.Select(x => new
                {
                    id = x.InsuranceId,
                    name = x.Name
                    //active = x.Active
                }));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
