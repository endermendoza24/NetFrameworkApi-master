using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApi.Controllers
{
    public class ToDosController : ApiController
    {
        private readonly IToDosService _toDosService;

        public ToDosController(IToDosService toDosService)
        {
            _toDosService = toDosService;
        }

        [HttpGet]
        public IHttpActionResult GetToDos()
        {
            List<ToDo> toDos = _toDosService.GetAll();
            return Ok(toDos);
        }
    }
}
