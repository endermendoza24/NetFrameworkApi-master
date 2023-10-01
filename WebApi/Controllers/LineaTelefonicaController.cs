using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Application.Endpoint;

namespace WebApi.Controllers
{
    public class LineaTelefonicaController : ApiController
    {
        private EntityStore<Linea_Telefonica> _lineaTelefonicaStore;

        public LineaTelefonicaController()
        {
            _lineaTelefonicaStore = new EntityStore<Linea_Telefonica>(l => l.ID);
        }

        [HttpGet]
        public IHttpActionResult ObtenerLineasTelefonicas()
        {
            try
            {
                List<Linea_Telefonica> lineasTelefonicas = _lineaTelefonicaStore.ObtenerTodo();
                return Ok(lineasTelefonicas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerLineaTelefonica(int id)
        {
            try
            {
                Linea_Telefonica lineaTelefonica = _lineaTelefonicaStore.ObtenerPorId(id);

                if (lineaTelefonica == null)
                    return NotFound();

                return Ok(lineaTelefonica);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarLineaTelefonica([FromBody] Linea_Telefonica nuevaLineaTelefonica)
        {
            try
            {
                _lineaTelefonicaStore.Agregar(nuevaLineaTelefonica);
                List<Linea_Telefonica> lineasTelefonicas = _lineaTelefonicaStore.ObtenerTodo();
                return Ok(lineasTelefonicas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarLineaTelefonica(int id, [FromBody] Linea_Telefonica lineaTelefonicaActualizada)
        {
            try
            {
                _lineaTelefonicaStore.Actualizar(id, lineaTelefonicaActualizada);
                List<Linea_Telefonica> lineasTelefonicas = _lineaTelefonicaStore.ObtenerTodo();
                return Ok(lineasTelefonicas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarLineaTelefonica(int id)
        {
            try
            {
                _lineaTelefonicaStore.Eliminar(id);
                List<Linea_Telefonica> lineasTelefonicas = _lineaTelefonicaStore.ObtenerTodo();
                return Ok(lineasTelefonicas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
