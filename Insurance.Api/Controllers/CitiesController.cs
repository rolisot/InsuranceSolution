using Insurance.Domain.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Insurance.Api.Controllers
{
    [RoutePrefix("api/states/{stateId}/cities")]
    public class CitiesController : ApiController
    {
        private ICityService _service;

        public CitiesController(ICityService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> GetCities(int stateId)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var list = _service.GetAll(stateId);
                response = Request.CreateResponse(HttpStatusCode.OK, list.Select(x => new
                {
                    cityId = x.CityId,
                    name = x.Name
                    //state = x.State,
                    //capital = x.Capital
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
                var city = _service.GetById(id);
                response = Request.CreateResponse(HttpStatusCode.OK, city);
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
