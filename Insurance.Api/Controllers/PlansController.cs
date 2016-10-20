using Insurance.Api.Contracts;
using Insurance.Common.Resources;
using Insurance.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Insurance.Api.Controllers
{
    [RoutePrefix("api/plans")]
    public class PlansController : ApiController
    {
        private IPlanService service;

        public PlansController(IPlanService context)
        {
            this.service = context;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetPlans()
        {
            try
            {
                var list = service.GetAll();

                if (list == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest);

                return Request.CreateResponse(HttpStatusCode.OK, list.Select(x => new
                {
                    id = x.PlanId,
                    description = x.Description,
                    price = x.Price,
                    days = x.Days
                }));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetPlanById(int id)
        {
            try
            {
                if (id == 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest);

                var plan = service.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, plan);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage PostPlan(CreatePlanContract contract)
        {
            if (contract == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                service.Create(contract.Description, contract.Price, contract.Days);
                return Request.CreateResponse(HttpStatusCode.OK, Messages.PlanSuccessfulyRegistered);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
