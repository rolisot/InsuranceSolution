using Insurance.Common.Resources;
using Insurance.Domain.Contracts;
using Insurance.Domain.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Insurance.Api.Controllers
{
    [RoutePrefix("api/quotations/{quotationId}/brokers")]
    [Authorize]
    public class QuotationBrokersController : ApiController
    {
        private IQuotationService quotationService;
        private IBrokerService brokerService;

        public QuotationBrokersController(IQuotationService quotationContext, IBrokerService brokerContext)
        {
            this.quotationService = quotationContext;
            this.brokerService = brokerContext;
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post()
        {
            var quotationId = Request.GetRouteData().Values["quotationId"];

            if (quotationId == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                quotationService.AddQuotationBroker(Convert.ToInt32(quotationId));
                return Request.CreateResponse(HttpStatusCode.OK, Messages.QuotationSuccessfulyRegistered);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
