using Insurance.Domain.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Insurance.Api.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    [Authorize]
    [RoutePrefix("api/states")]
    public class StatesController : ApiController
    {
        private IStateService _service;

        public StatesController(IStateService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> GetStates()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var list = _service.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, list.Select(x => new
                {
                    id = x.StateId,
                    name = x.Name,
                    abbreviation = x.Abbreviation
                }));
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return await this.GetTask(response);
        }


        [HttpGet]
        [Route("{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var state = _service.GetById(id);
                response = Request.CreateResponse(HttpStatusCode.OK, state);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return this.GetTask(response);
        }

        private Task<HttpResponseMessage> GetTask(HttpResponseMessage response)
        {
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

    }
}
